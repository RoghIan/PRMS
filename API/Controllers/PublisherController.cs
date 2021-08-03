using System.Collections.Generic;
using System.Linq;
using API.DTO;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PublisherController : BaseApiController
    {
        private readonly IGenericRepository<Publisher> _publisherRepo;
        private readonly IGenericRepository<Group> _groupRepo;
        //private readonly IGenericRepository<Appointed> _titleRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PublisherController(
            IGenericRepository<Publisher> publisherRepo,
            IMapper mapper, IGenericRepository<Group> groupRepo,
            //IGenericRepository<Appointed> titleRepo,
            IUnitOfWork unitOfWork)
        {
            _publisherRepo = publisherRepo;
            _mapper = mapper;
            _groupRepo = groupRepo;
            //_titleRepo = titleRepo;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PublisherToReturnDto>>> GetPublishers(
            [FromQuery] PublisherSpecParams publisherParams)
        {
            var spec = new PublisherWithGroupTitleStatusReport(publisherParams);
            var countSpec = new PublisherWithFiltersForCountSpecification(publisherParams);

            var totalItems = await _publisherRepo.CountAsync(countSpec);

            var publishers = await _publisherRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Publisher>, IReadOnlyList<PublisherToReturnDto>>(publishers);

            return Ok(new Pagination<PublisherToReturnDto>(publisherParams.PageSize,
                publisherParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublisherToReturnDto>> GetPublisher(int id)
        {
            var spec = new PublisherWithGroupTitleStatusReport(id);
            var publisher = await _publisherRepo.GetEntityWithSpec(spec);

            if (publisher == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Publisher, PublisherToReturnDto>(publisher);
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Publisher>> Put(int id, [FromBody] Publisher newPublisher)
        {
            var spec = new PublisherWithGroupTitleStatusReport(id);
            //var publisher = await _unitOfWork.Repository<Publisher>().GetEntityWithSpec(spec);

            var pubAppointees = await _unitOfWork.Repository<AppointedPublisher>().BasicListAsync(x => x.PublisherId == id);
            
             //remove titles
             foreach (var prevAppointee in pubAppointees)
             {
                 if (newPublisher.AppointedPublishers.Any(x => x.AppointedId == prevAppointee.AppointedId)) continue;
                 
                 var titleToRemove = await _unitOfWork.Repository<AppointedPublisher>()
                     .BasicGetEntityWithSpec(x => x.AppointedId == prevAppointee.AppointedId && x.PublisherId == prevAppointee.PublisherId);
                 
                 if(titleToRemove == null) continue;
                 
                 _unitOfWork.Repository<AppointedPublisher>().Delete(titleToRemove);
             }
            
             //update and insert appointed
             foreach (var newAppointed in newPublisher.AppointedPublishers)
             {
                 var existingTitle = await _unitOfWork.Repository<AppointedPublisher>()
                     .BasicGetEntityWithSpec(x => x.PublisherId == id && x.AppointedId == newAppointed.AppointedId);
            
                 if (existingTitle != null)
                 {
                     _unitOfWork.Repository<AppointedPublisher>().Update(newAppointed);
                 }
                 else
                 {
                     _unitOfWork.Repository<AppointedPublisher>().Add(newAppointed);
                 }
             }

            // if (publisher != null)
            // {
            //     publisher = newPublisher;
            // }
            
            _unitOfWork.Repository<Publisher>().Update(newPublisher);
            
            var result = await _unitOfWork.Complete();

            return result <= 0 ? null : newPublisher;
        }
        

        [HttpGet("groups")]
        public async Task<ActionResult<IReadOnlyList<Group>>> GetPublisherGroups()
        {
            return Ok(await _groupRepo.ListAllAsync());
        }
    }
}