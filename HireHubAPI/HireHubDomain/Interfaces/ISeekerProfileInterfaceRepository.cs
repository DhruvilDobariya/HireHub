using HireHubDomain.Entities;

namespace HireHubDomain.Interfaces
{
    public interface ISeekerProfileRepository : IGenericRepository<SeekerProfile>
    {
        Task<SeekerProfile?> GetByUserIdAsync(int userId);
    }
}
