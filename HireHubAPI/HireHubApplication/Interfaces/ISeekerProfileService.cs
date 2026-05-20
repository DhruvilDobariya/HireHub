using HireHubApplication.DTOs;
using HireHubDomain.Entities;

namespace HireHubApplication.Interfaces
{
    public interface ISeekerProfileService
    {
        Task<Response> GetProfileByUserIdAsync(int userId);
        Task<Response> GetProfileByIdAsync(int id);
        Task<Response> CreateProfileAsync(SeekerProfile profile);
        Task<Response> UpdateProfileAsync(SeekerProfile profile);
        Task<Response> DeleteProfileAsync(int id);
    }
}