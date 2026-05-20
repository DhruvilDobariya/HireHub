using HireHubApplication.Interfaces;
using HireHubDomain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeekerProfilesController : ControllerBase
    {
        private readonly ISeekerProfileService _profileService;

        public SeekerProfilesController(ISeekerProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetProfileByUserId(int userId)
        {
            var response = await _profileService.GetProfileByUserIdAsync(userId);
            if (response.IsError) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "JobSeeker")]
        public async Task<IActionResult> CreateProfile([FromBody] SeekerProfile profile)
        {
            var response = await _profileService.CreateProfileAsync(profile);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "JobSeeker")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] SeekerProfile profile)
        {
            profile.Id = id;
            var response = await _profileService.UpdateProfileAsync(profile);
            return Ok(response);
        }
    }
}