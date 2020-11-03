using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Status> _statusRepository;

        public StatusController(IMapper mapper, IGenericRepository<Status> statusRepository)
        {
            _mapper = mapper;
            _statusRepository = statusRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PropertyDto>>> Statuses(
            [FromQuery] StatusSpecParams statusSpecParams)
        {
            var spec = new StatusWithPublishers();
            var statuses = await _statusRepository.ListAsync(spec);

            var countSpec = new StatusWithFiltersForCountSpecification(statusSpecParams);
            var totalItems = await _statusRepository.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<Status>, IReadOnlyList<PropertyDto>>(statuses);

            return Ok(new Pagination<PropertyDto>(statusSpecParams.PageSize,
                statusSpecParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> Status(int id)
        {
            var spec = new StatusWithPublishers(id);
            var status = await _statusRepository.GetEntityWithSpec(spec);

            var statusToReturnDto = _mapper.Map<Status, PropertyDto>(status);

            return statusToReturnDto;
        }
    }
}