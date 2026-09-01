using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Dtos.ShowTimeDtos
{
    public class CreateUpdateShowTimeDto
    {
        [Required(ErrorMessage = "StartTime is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "MovieId is required")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "AuditoriumId is required")]
        public int AuditoriumId { get; set; }
    }
}
