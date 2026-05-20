using HireHubDomain.Entities;
using HireHubDomain.Interfaces;
using HireHubInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HireHubInfrastructure.Services
{
    public class JobApplicationRepository : GenericRepository<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(HireHubDBContext context) : base(context) { }

        public async Task<IEnumerable<JobApplication>> GetByJobIdAsync(int jobId)
        {
            return await _dbSet
                .Include(a => a.Seeker)
                .Where(a => a.JobId == jobId)
                .ToListAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetBySeekerIdAsync(int seekerId)
        {
            return await _dbSet
                .Include(a => a.Job)
                .ThenInclude(j => j.Company)
                .Where(a => a.SeekerId == seekerId)
                .ToListAsync();
        }

        public async Task<bool> AlreadyAppliedAsync(int jobId, int seekerId)
        {
            return await _dbSet.AnyAsync(a => a.JobId == jobId && a.SeekerId == seekerId);
        }

        public async Task<JobApplication?> GetByJobAndSeekerAsync(int jobId, int seekerId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(a => a.JobId == jobId && a.SeekerId == seekerId);
        }
    }

}
