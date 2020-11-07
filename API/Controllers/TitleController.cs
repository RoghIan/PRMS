using API.DTO;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitleController : ControllerBase
    {
        private readonly IGenericRepository<Title> _titleRepo;
        private readonly IMapper _mapper;

        public TitleController(IGenericRepository<Title> titleRepo, DataContext context, IMapper mapper)
        {
            _titleRepo = titleRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PropertyDto>>> Titles([FromQuery] TitleSpecParams titleSpecParams)
        {
            var spec = new TitleWithPublishersSpecification(titleSpecParams);
            var titles = await _titleRepo.ListAsync(spec);

            var countSpec = new TitleWithPublishersSpecification(titleSpecParams);
            var totalItems = await _titleRepo.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<Title>, IReadOnlyList<PropertyDto>>(titles);

            return Ok(new Pagination<PropertyDto>(titleSpecParams.PageSize,
                titleSpecParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> Title(int id)
        {
            var spec = new TitleWithPublishersSpecification(id);

            var title = await _titleRepo.GetEntityWithSpec(spec);

            return Ok(title);
        }
    }
}