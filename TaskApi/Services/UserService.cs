using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskApi.Dtos.UserDtos;
using TaskApi.Enums;
using TaskApi.Models;
using TaskApi.Repositories;

namespace TaskApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository ,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Users> CreateUser(Users user)
        {
            return await _userRepository.CreateUser(user);
        }

        public string GenerateToken(Users user)
        {
            var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpiryMinutes"]!)),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<string> Login(LoginRequestDto dto)
        {
            var user = await _userRepository.GetByEmail(dto.Email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null; 

            return GenerateToken(user);
        }

        public async Task<Users> Register(RegisterRequestDto dto)
        {
            var exists = await _userRepository.GetByEmail(dto.Email);
            if (exists is not null) return null; 

            var user = new Users
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = Role.User
            };
            return await _userRepository.CreateUser(user);
        }
    }
}
