using HireHubDomain.Entities;

namespace HireHubDomain.Interfaces
{
    public interface IJobApplicationRepository : IGenericRepository<JobApplication>
    {
        Task<IEnumerable<JobApplication>> GetByJobIdAsync(int jobId);
        Task<IEnumerable<JobApplication>> GetBySeekerIdAsync(int seekerId);
        Task<bool> AlreadyAppliedAsync(int jobId, int seekerId);
        Task<JobApplication?> GetByJobAndSeekerAsync(int jobId, int seekerId);
    }

}
