using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Dtos.AudiotoriumDtos
{
    public class CreateUpdateAuditoriumDto
    {
        [Required(ErrorMessage = "Room number is required.")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000 seats.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Availability status is required.")]
        public bool Available { get; set; }
    }
}
