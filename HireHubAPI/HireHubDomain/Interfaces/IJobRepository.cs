using HireHubDomain.Entities;

namespace HireHubDomain.Interfaces
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<IEnumerable<Job>> GetAllWithCompanyAsync();
        Task<Job?> GetByIdWithCompanyAsync(int id);
        Task<IEnumerable<Job>> SearchAsync(string? title, string? location);
        Task<IEnumerable<Job>> GetByCompanyIdAsync(int companyId);
    }

}
