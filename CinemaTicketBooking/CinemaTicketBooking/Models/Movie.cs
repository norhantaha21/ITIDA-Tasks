namespace CinemaTicketBooking.Models
{
    public class Movie :BaseEntity
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool AvailableInCinema { get; set; }

        //Navigation property
        public ICollection<ShowTime> Shows { get; set; } = new List<ShowTime>();
    }
}
