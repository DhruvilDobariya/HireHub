using HireHubApplication.DTOs;
using HireHubApplication.Interfaces;
using HireHubDomain.Entities;
using HireHubDomain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HireHubApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<Response> RegisterAsync(RegisterDto dto)
        {
            if (await _userRepo.EmailExistsAsync(dto.Email))
                return new Response { IsError = true, Message = "Email already in use." };

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepo.AddAsync(user);
            return new Response { Message = "Registration successful." };
        }




        public async Task<Response> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return new Response { IsError = true, Message = "Invalid Email or Password." };
            }

            string token = GenerateToken(user);

            return new Response
            {
                Message = "Login successful.",
                Data = new { Token = token, Role = user.Role }
            };
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var jwtKey = _config["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey)) throw new Exception("JWT Key is missing in config.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Response> GetUserByEmailAsync(string email)
        {
            var user = await _userRepo.GetByEmailAsync(email);
            if (user == null) return new Response { IsError = true, Message = "User not found." };
            return new Response { Data = user };
        }

        public async Task<Response> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return new Response { IsError = true, Message = "User not found." };
            return new Response { Data = user };
        }

        public async Task<Response> DeleteUserAsync(int id)
        {
            await _userRepo.DeleteAsync(id);
            return new Response { Message = "User account removed." };
        }
    }
}