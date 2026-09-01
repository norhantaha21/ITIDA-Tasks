using TaskApi.Models;

namespace TaskApi.Services
{
    public interface IUserService
    {
        Task<Users> CreateUser(Users user);
        Task<List<Users>> GetAllUsers();
    }
}
