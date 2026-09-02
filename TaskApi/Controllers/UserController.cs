using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using TaskApi.Dtos.UserDtos;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Controllers
{
        [ApiController]
        [Route("/api/user")]
        public class UserController:ControllerBase
        {
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpPost]
            public async Task<ActionResult> CreateUser(Users user)
            {
                return Ok(await _userService.CreateUser(user));
            }

            [HttpGet]
            public async Task<ActionResult> GetAllUsers()
            {
                return Ok(_userService.GetAllUsers()); 
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterRequestDto dto)
            {
                var result = await _userService.Register(dto);
                if (result is null) return Conflict(new { message = "Email already registered." });
                return Ok(result);
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginRequestDto dto)
            {
                var token = await _userService.Login(dto);
                if (token is null) return Unauthorized(new { message = "Invalid credentials." });
                return Ok(new { accessToken = token });
            }
        }
    }