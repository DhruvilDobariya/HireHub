using HireHubDomain.Entities;
using HireHubDomain.Interfaces;
using HireHubInfrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace HireHubInfrastructure.Services
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(HireHubDBContext context) : base(context) { }

        public async Task<Company?> GetByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
