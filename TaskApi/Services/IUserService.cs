using TaskApi.Dtos.UserDtos;
using TaskApi.Models;

namespace TaskApi.Services
{
    public interface IUserService
    {
        Task<Users> CreateUser(Users user);
        Task<List<Users>> GetAllUsers();
        Task<Users> Register(RegisterRequestDto dto);
        Task<string> Login(LoginRequestDto dto);
        string GenerateToken(Users user);
    }
}
