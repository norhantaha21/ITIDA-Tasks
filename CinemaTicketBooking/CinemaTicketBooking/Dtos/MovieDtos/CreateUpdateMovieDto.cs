using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBooking.Dtos.MovieDtos
{
    public class CreateUpdateMovieDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool AvailableInCinema { get; set; }
    }
}
