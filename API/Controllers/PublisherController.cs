using System.Collections.Generic;
using API.DTO;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PublisherController : BaseApiController
    {
        private readonly IGenericRepository<Publisher> _publisherRepo;
        private readonly IGenericRepository<Group> _groupRepo;
        private readonly IGenericRepository<Title> _titleRepo;
        private readonly IGenericRepository<Status> _statusRepo;
        private readonly IMapper _mapper;

        public PublisherController(
            IGenericRepository<Publisher> publisherRepo,
            IMapper mapper, IGenericRepository<Group> groupRepo,
            IGenericRepository<Title> titleRepo,
            IGenericRepository<Status> statusRepo)
        {
            _publisherRepo = publisherRepo;
            _mapper = mapper;
            _groupRepo = groupRepo;
            _titleRepo = titleRepo;
            _statusRepo = statusRepo;
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

        [HttpGet("titles")]
        public async Task<ActionResult<IReadOnlyList<Title>>> GetPublisherTitles()
        {
            return Ok(await _titleRepo.ListAllAsync());
        }

        [HttpGet("groups")]
        public async Task<ActionResult<IReadOnlyList<Group>>> GetPublisherGroups()
        {
            return Ok(await _groupRepo.ListAllAsync());
        }

        [HttpGet("statuses")]
        public async Task<ActionResult<IReadOnlyList<Status>>> GetPublisherStatus()
        {
            return Ok(await _statusRepo.ListAllAsync());
        }
    }
}