using API.DTO;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class ReportController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ReportController>
        [HttpGet]
        public async Task<ActionResult<Pagination<ReportToReturnDto>>> Get([FromQuery] ReportSpecParams specParams)
        {
            var spec = new ReportWithPublisherSpecification(specParams);

            var reports = await _unitOfWork.Repository<Report>().ListAsync(spec);
            var totalItems = await _unitOfWork.Repository<Report>().CountAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Report>, IReadOnlyList<ReportToReturnDto>>(reports);

            return Ok(new Pagination<ReportToReturnDto>(specParams.PageSize,
                specParams.PageSize, totalItems, data));
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportToReturnDto>> Get(int id)
        {
            var spec = new ReportWithPublisherSpecification(id);
            var report = await _unitOfWork.Repository<Report>().GetEntityWithSpec(spec);

            if (report == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Report, ReportToReturnDto>(report);
        }

        // POST api/<ReportController>
        [HttpPost]
        public async Task<ActionResult<Report>> Post([FromBody] Report report)
        {
            _unitOfWork.Repository<Report>().Add(report);
            var result = await _unitOfWork.Complete();

            return result <= 0 ? null : report;
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Report>> Put(int reportId, [FromBody] Report newReport)
        {
            var spec = new ReportWithPublisherSpecification(reportId);
            var report = await _unitOfWork.Repository<Report>().GetEntityWithSpec(spec);

            if (report != null)
            {
                report = newReport;
            }
            
            _unitOfWork.Repository<Report>().Update(report);
            var result = await _unitOfWork.Complete();

            return result <= 0 ? null : report;
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var spec = new ReportWithPublisherSpecification(id);
            var report = await _unitOfWork.Repository<Report>().GetEntityWithSpec(spec);
            
            _unitOfWork.Repository<Report>().Delete(report);
            var result = await _unitOfWork.Complete();

            return result <= 0 ;
        }
    }
}