using HireHubApplication.DTOs;

namespace HireHubApplication.Interfaces
{
    public interface IJobApplicationService
    {
        Task<Response> ApplyAsync(int jobId, int seekerId);
        Task<Response> GetApplicationsByJobAsync(int jobId);
        Task<Response> GetApplicationsBySeekerAsync(int seekerId);
        Task<Response> WithdrawApplicationAsync(int applicationId);
    }
}