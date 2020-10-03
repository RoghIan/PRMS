using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<List<Title>>> Titles()
        {
            var spec = new TitleWithPublishers();
            var titles = await _titleRepo.ListAsync(spec);

            var titlesToReturnDto = titles.Select(t => _mapper.Map<Title, PropertyDto>(t));

            return Ok(titlesToReturnDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> Title(int id)
        {
            var spec = new TitleWithPublishers(id);

            var title = await _titleRepo.GetEntityWithSpec(spec);

            return Ok(title);
        }
    }

}
