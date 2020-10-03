using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
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
    public class GroupController : ControllerBase
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
            var spec = new GroupWithPublishers();
            var groups = await _groupRepository.ListAsync(spec);

            var groupToReturnDto = groups.Select(g => _mapper.Map<Group, PropertyDto>(g)).ToList();

            return groupToReturnDto;
        }
    }
}
