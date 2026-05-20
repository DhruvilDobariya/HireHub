using HireHubDomain.Entities;

namespace HireHubDomain.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company?> GetByUserIdAsync(int userId);
        Task AddAsync(Company company);
        Task<bool> NameExistsAsync(string name);
    }
}
