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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class ReportController : BaseApiController
    {
        private readonly IGenericRepository<Report> _reportRepo;
        private readonly IMapper _mapper;

        public ReportController(IGenericRepository<Report> reportRepo, IMapper mapper)
        {
            _reportRepo = reportRepo;
            _mapper = mapper;
        }

        // GET: api/<ReportController>
        [HttpGet]
        public async Task<ActionResult<Pagination<ReportToReturnDto>>> Get([FromQuery] ReportSpecParams specParams)
        {
            var spec = new ReportWithPublisherSpecification(specParams);

            var reports = await _reportRepo.ListAsync(spec);
            var totalItems = await _reportRepo.CountAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Report>, IReadOnlyList<ReportToReturnDto>>(reports);

            return Ok(new Pagination<ReportToReturnDto>(specParams.PageSize,
                specParams.PageSize, totalItems, data));
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportToReturnDto>> Get(int id)
        {
            var spec = new ReportWithPublisherSpecification(id);
            var report = await _reportRepo.GetEntityWithSpec(spec);

            if (report == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Report, ReportToReturnDto>(report);
        }

        // POST api/<ReportController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}