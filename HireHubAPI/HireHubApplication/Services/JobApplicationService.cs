using HireHubApplication.DTOs;
using HireHubApplication.Interfaces;
using HireHubDomain.Entities;
using HireHubDomain.Interfaces;

namespace HireHubApplication.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _appRepo;

        public JobApplicationService(IJobApplicationRepository appRepo)
        {
            _appRepo = appRepo;
        }

        public async Task<Response> ApplyAsync(int jobId, int seekerId)
        {
            if (await _appRepo.AlreadyAppliedAsync(jobId, seekerId))
            {
                return new Response { IsError = true, Message = "You have already applied for this position." };
            }

            var application = new JobApplication
            {
                JobId = jobId,
                SeekerId = seekerId,
                AppliedAt = DateTime.UtcNow
            };

            await _appRepo.AddAsync(application);
            return new Response { Message = "Application submitted successfully.", Data = application };
        }

        public async Task<Response> GetApplicationsByJobAsync(int jobId)
        {
            var applications = await _appRepo.GetByJobIdAsync(jobId);
            return new Response { Data = applications };
        }

        public async Task<Response> GetApplicationsBySeekerAsync(int seekerId)
        {
            var applications = await _appRepo.GetBySeekerIdAsync(seekerId);
            return new Response { Data = applications };
        }

        public async Task<Response> WithdrawApplicationAsync(int applicationId)
        {
            await _appRepo.DeleteAsync(applicationId);
            return new Response { Message = "Application withdrawn successfully." };
        }
    }
}