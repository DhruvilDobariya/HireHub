using HireHubApplication.Interfaces;
using HireHubDomain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCompanies()
        {
            var response = await _companyService.GetAllCompaniesAsync();
            return Ok(response);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetCompanyByUserId(int userId)
        {
            var response = await _companyService.GetCompanyByUserIdAsync(userId);
            return Ok(response);
        }

        //[HttpPost]
        //[Authorize(Roles = "Employer")]
        //public async Task<IActionResult> CreateCompany([FromBody] Company company)
        //{
        //    var response = await _companyService.CreateCompanyAsync(company);
        //    return Ok(response);
        //}

        [HttpPut("{id}")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company company)
        {
            company.Id = id;
            var response = await _companyService.UpdateCompanyAsync(company);
            return Ok(response);
        }
    }
}