using HireHubApplication.DTOs;
using HireHubApplication.Interfaces;
using HireHubDomain.Entities;
using HireHubDomain.Interfaces;

namespace HireHubApplication.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepo;

        public JobService(IJobRepository jobRepo)
        {
            _jobRepo = jobRepo;
        }

        public async Task<Response> GetAllJobsAsync()
        {
            var jobs = await _jobRepo.GetAllWithCompanyAsync();
            return new Response { Data = jobs };
        }

        public async Task<Response> GetJobByIdAsync(int id)
        {
            var job = await _jobRepo.GetByIdWithCompanyAsync(id);
            if (job == null) return new Response { IsError = true, Message = "Job not found." };
            return new Response { Data = job };
        }

        public async Task<Response> SearchJobsAsync(string? title, string? location)
        {
            var jobs = await _jobRepo.SearchAsync(title, location);
            return new Response { Data = jobs };
        }

        public async Task<Response> GetJobsByCompanyAsync(int companyId)
        {
            var jobs = await _jobRepo.GetByCompanyIdAsync(companyId);
            return new Response { Data = jobs };
        }

        public async Task<Response> CreateJobAsync(Job job)
        {
            await _jobRepo.AddAsync(job);
            return new Response { Message = "Job created successfully.", Data = job };
        }

        public async Task<Response> UpdateJobAsync(Job job)
        {
            await _jobRepo.UpdateAsync(job);
            return new Response { Message = "Job updated successfully." };
        }

        public async Task<Response> DeleteJobAsync(int id)
        {
            await _jobRepo.DeleteAsync(id);
            return new Response { Message = "Job deleted successfully." };
        }
    }
}