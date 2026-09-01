using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Dtos.CustomerDtos
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
    }
}
