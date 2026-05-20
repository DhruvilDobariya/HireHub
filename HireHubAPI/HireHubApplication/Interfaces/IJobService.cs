using HireHubApplication.DTOs;
using HireHubDomain.Entities;

namespace HireHubApplication.Interfaces
{
    public interface IJobService
    {
        Task<Response> GetAllJobsAsync();
        Task<Response> GetJobByIdAsync(int id);
        Task<Response> SearchJobsAsync(string? title, string? location);
        Task<Response> GetJobsByCompanyAsync(int companyId);
        Task<Response> CreateJobAsync(Job job);
        Task<Response> UpdateJobAsync(Job job);
        Task<Response> DeleteJobAsync(int id);
    }
}