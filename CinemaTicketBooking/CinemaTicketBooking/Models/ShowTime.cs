namespace CinemaTicketBooking.Models
{
    public class ShowTime :BaseEntity
    {
        public DateTime StartTime { get; set; }
        //FK
        public int MovieId { get; set; }
        public int AuditoriumId { get; set; }

        //Navigation property
        public Movie Movie { get; set; }
        public Auditorium Auditorium { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
