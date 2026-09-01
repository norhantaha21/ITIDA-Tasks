namespace CinemaTicketBooking.Dtos.MovieDtos
{
    public class MovieV2Dto: MovieV1Dto
    {
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
