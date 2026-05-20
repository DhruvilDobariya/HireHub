using HireHubDomain.Entities;
using HireHubDomain.Interfaces;
using HireHubInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HireHubInfrastructure.Services
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(HireHubDBContext context) : base(context) { }

        public async Task<IEnumerable<Job>> GetAllWithCompanyAsync()
        {
            return await _dbSet
                .Include(j => j.Company)
                .ToListAsync();
        }

        public async Task<Job?> GetByIdWithCompanyAsync(int id)
        {
            return await _dbSet
                .Include(j => j.Company)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<Job>> SearchAsync(string? title, string? location)
        {
            var query = _dbSet.Include(j => j.Company).AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(j => j.Title.Contains(title));

            if (!string.IsNullOrEmpty(location))
                query = query.Where(j => j.Location.Contains(location));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Job>> GetByCompanyIdAsync(int companyId)
        {
            return await _dbSet
                .Where(j => j.CompanyId == companyId)
                .ToListAsync();
        }
    }
}
