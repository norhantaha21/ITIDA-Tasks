using System.ComponentModel.DataAnnotations;

namespace TaskApi.Dtos.UserDtos
{
    public class LoginRequestDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
