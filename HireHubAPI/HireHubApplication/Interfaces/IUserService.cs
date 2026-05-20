using HireHubApplication.DTOs;

namespace HireHubApplication.Interfaces
{
    public interface IUserService
    {
        Task<Response> LoginAsync(LoginDto dto);
        Task<Response> RegisterAsync(RegisterDto user);
        Task<Response> GetUserByEmailAsync(string email);
        Task<Response> GetUserByIdAsync(int id);
        Task<Response> DeleteUserAsync(int id);
    }
}