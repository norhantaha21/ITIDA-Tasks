using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
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
    }
}
