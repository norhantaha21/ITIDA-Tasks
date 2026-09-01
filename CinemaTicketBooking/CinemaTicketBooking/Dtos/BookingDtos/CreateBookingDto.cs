using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [MaxLength(150)]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required]
        public int ShowTimeId { get; set; }
    }
}
