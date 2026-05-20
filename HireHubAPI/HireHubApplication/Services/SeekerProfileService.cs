using HireHubApplication.DTOs;
using HireHubApplication.Interfaces;
using HireHubDomain.Entities;
using HireHubDomain.Interfaces;

namespace HireHubApplication.Services
{
    public class SeekerProfileService : ISeekerProfileService
    {
        private readonly ISeekerProfileRepository _seekerRepo;

        public SeekerProfileService(ISeekerProfileRepository seekerRepo)
        {
            _seekerRepo = seekerRepo;
        }

        public async Task<Response> GetProfileByUserIdAsync(int userId)
        {
            var profile = await _seekerRepo.GetByUserIdAsync(userId);
            if (profile == null) return new Response { IsError = true, Message = "Profile not found." };
            return new Response { Data = profile };
        }

        public async Task<Response> GetProfileByIdAsync(int id)
        {
            var profile = await _seekerRepo.GetByIdAsync(id);
            if (profile == null) return new Response { IsError = true, Message = "Profile not found." };
            return new Response { Data = profile };
        }

        public async Task<Response> CreateProfileAsync(SeekerProfile profile)
        {
            var existing = await _seekerRepo.GetByUserIdAsync(profile.UserId);
            if (existing != null)
            {
                return new Response { IsError = true, Message = "Profile already exists for this user." };
            }

            await _seekerRepo.AddAsync(profile);
            return new Response { Message = "Profile created successfully.", Data = profile };
        }

        public async Task<Response> UpdateProfileAsync(SeekerProfile profile)
        {
            await _seekerRepo.UpdateAsync(profile);
            return new Response { Message = "Profile updated successfully." };
        }

        public async Task<Response> DeleteProfileAsync(int id)
        {
            await _seekerRepo.DeleteAsync(id);
            return new Response { Message = "Profile deleted successfully." };
        }
    }
}