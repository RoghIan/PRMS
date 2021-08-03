using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GroupController : BaseApiController
    {
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IMapper _mapper;

        public GroupController(IGenericRepository<Group> groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PropertyDto>>> Groups([FromQuery] GroupSpecParams groupSpecParams)
        {
            var spec = new GroupWithPublishersSpecification(groupSpecParams);
            var groups = await _groupRepository.ListAsync(spec);

            var countSpec = new GroupWithFiltersForCountSpecification(groupSpecParams);
            var totalItems = await _groupRepository.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<Group>, IReadOnlyList<PropertyDto>>(groups);

            return Ok(new Pagination<PropertyDto>(groupSpecParams.PageSize,
                groupSpecParams.PageSize, totalItems, data));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PropertyDto>> Group(int id)
        {
            var spec = new GroupWithPublishersSpecification(id);
            var group = await _groupRepository.GetEntityWithSpec(spec);

            var groupToReturnDto = _mapper.Map<Group, PropertyDto>(group);

            if (group == null) return NotFound(new ApiResponse(404));

            return groupToReturnDto;
        }
    }
}