using HireHubApplication.DTOs;
using HireHubApplication.Interfaces;
using HireHubDomain.Entities;
using HireHubDomain.Interfaces;

namespace HireHubApplication.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task<Response> GetCompanyByUserIdAsync(int userId)
        {
            var company = await _companyRepo.GetByUserIdAsync(userId);
            if (company == null) return new Response { IsError = true, Message = "Company profile not found." };
            return new Response { Data = company };
        }

        public async Task<Response> GetAllCompaniesAsync()
        {
            var companies = await _companyRepo.GetAllAsync();
            return new Response { Data = companies };
        }

        public async Task<Response> UpdateCompanyAsync(Company company)
        {
            await _companyRepo.UpdateAsync(company);
            return new Response { Message = "Company profile updated successfully." };
        }
    }
}