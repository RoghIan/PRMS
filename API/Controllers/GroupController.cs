using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IReadOnlyList<PropertyDto>>> Groups()
        {
            var spec = new GroupWithPublishersSpecification();
            var groups = await _groupRepository.ListAsync(spec);

            var groupToReturnDto = groups.Select(g => _mapper.Map<Group, PropertyDto>(g)).ToList();

            return groupToReturnDto;
        }

        [HttpGet("{id}")]
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