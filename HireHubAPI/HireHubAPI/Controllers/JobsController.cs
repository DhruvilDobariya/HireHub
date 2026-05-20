using HireHubApplication.Interfaces;
using HireHubDomain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // ── Public ───────────────────────────────────────────────────
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllJobs()
        {
            var response = await _jobService.GetAllJobsAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetJobById(int id)
        {
            var response = await _jobService.GetJobByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchJobs([FromQuery] string? title, [FromQuery] string? location)
        {
            var response = await _jobService.SearchJobsAsync(title, location);
            return Ok(response);
        }

        [HttpGet("company/{companyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetJobsByCompany(int companyId)
        {
            var response = await _jobService.GetJobsByCompanyAsync(companyId);
            return Ok(response);
        }

        // ── Employer only ────────────────────────────────────────────
        [HttpPost]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> CreateJob([FromBody] Job job)
        {
            var response = await _jobService.CreateJobAsync(job);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] Job job)
        {
            job.Id = id;
            var response = await _jobService.UpdateJobAsync(job);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var response = await _jobService.DeleteJobAsync(id);
            return Ok(response);
        }
    }
}