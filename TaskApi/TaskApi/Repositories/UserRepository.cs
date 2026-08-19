using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskApi.Data;
using TaskApi.Models;

namespace TaskApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbcontext;

        public UserRepository(AppDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<Users> CreateUser(Users user)
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _dbcontext.Users.ToListAsync();
        }
    }
}
