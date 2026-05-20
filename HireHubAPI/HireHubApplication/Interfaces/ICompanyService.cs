using HireHubApplication.DTOs;
using HireHubDomain.Entities;

namespace HireHubApplication.Interfaces
{
    public interface ICompanyService
    {
        Task<Response> GetCompanyByUserIdAsync(int userId);
        Task<Response> GetAllCompaniesAsync();
        Task<Response> UpdateCompanyAsync(Company company);
    }
}