using HireHubDomain.Entities;
using HireHubDomain.Interfaces;
using HireHubInfrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace HireHubInfrastructure.Services
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HireHubDBContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.Email == email);
        }
    }
}
