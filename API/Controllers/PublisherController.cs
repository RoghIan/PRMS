using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PublisherController : BaseApiController
    {
        private readonly IGenericRepository<Publisher> _publisherRepo;
        private readonly IMapper _mapper;

        public PublisherController(IGenericRepository<Publisher> publisherRepo,
                                    IMapper mapper)
        {
            _publisherRepo = publisherRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PublisherToReturnDto>>> GetPublishers()
        {
            var spec = new PublisherWithGroupTitleStatusReport();
            var publishers = await _publisherRepo.ListAsync(spec);

            var publishersToReturnDto = publishers.Select(x => _mapper.Map<Publisher, PublisherToReturnDto>(x)).ToList();

            return publishersToReturnDto;
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
    }
}
