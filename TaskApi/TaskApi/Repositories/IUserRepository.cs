using TaskApi.Models;

namespace TaskApi.Repositories
{
    public interface IUserRepository
    {
        Task<Users> CreateUser(Users user);
        Task<List<Users>> GetAllUsers();
    }
}
