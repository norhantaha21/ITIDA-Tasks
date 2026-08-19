using TaskApi.Models;
using TaskApi.Repositories;

namespace TaskApi.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Users> CreateUser(Users user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
