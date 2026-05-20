using HireHubApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _applicationService;

        public ApplicationsController(IJobApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // ── JobSeeker only ───────────────────────────────────────────
        [HttpPost("apply")]
        [Authorize(Roles = "JobSeeker")]
        public async Task<IActionResult> Apply(int jobId, int seekerId)
        {
            var response = await _applicationService.ApplyAsync(jobId, seekerId);
            if (response.IsError) return BadRequest(response);
            return Ok(response);
        }

        [HttpDelete("{id}/withdraw")]
        [Authorize(Roles = "JobSeeker")]
        public async Task<IActionResult> WithdrawApplication(int id)
        {
            var response = await _applicationService.WithdrawApplicationAsync(id);
            return Ok(response);
        }

        [HttpGet("seeker/{seekerId}")]
        [Authorize(Roles = "JobSeeker")]
        public async Task<IActionResult> GetApplicationsForSeeker(int seekerId)
        {
            var response = await _applicationService.GetApplicationsBySeekerAsync(seekerId);
            return Ok(response);
        }

        // ── Employer only ────────────────────────────────────────────
        [HttpGet("job/{jobId}")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetApplicationsForJob(int jobId)
        {
            var response = await _applicationService.GetApplicationsByJobAsync(jobId);
            return Ok(response);
        }
    }
}