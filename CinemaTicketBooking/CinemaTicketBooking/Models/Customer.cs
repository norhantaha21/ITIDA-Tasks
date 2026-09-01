namespace CinemaTicketBooking.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation Property
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
