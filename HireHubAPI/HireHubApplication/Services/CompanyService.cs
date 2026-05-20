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

        public async Task<Response> CreateCompanyAsync(Company company)
        {
            // 1. Check if a company with the same name already exists
            var exists = await _companyRepo.NameExistsAsync(company.Name);
            if (exists) return new Response { IsError = true, Message = "Company name already registered." };

            // 2. Save to database via repository
            await _companyRepo.AddAsync(company);

            // 3. Return standard response structure
            return new Response
            {
                IsError = false,
                Message = "Company created successfully.",
                Data = company // Pass the created object back (it will now include its new Database ID)
            };
        }

        public async Task<Response> UpdateCompanyAsync(Company company)
        {
            await _companyRepo.UpdateAsync(company);
            return new Response { Message = "Company profile updated successfully." };
        }
    }
}