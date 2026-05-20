using HireHubDomain.Entities;
using HireHubDomain.Interfaces;
using HireHubInfrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace HireHubInfrastructure.Services
{
    public class SeekerProfileRepository : GenericRepository<SeekerProfile>, ISeekerProfileRepository
    {
        public SeekerProfileRepository(HireHubDBContext context) : base(context) { }

        public async Task<SeekerProfile?> GetByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }
}
