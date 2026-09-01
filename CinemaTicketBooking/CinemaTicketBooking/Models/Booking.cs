using CinemaTicketBooking.Enums;

namespace CinemaTicketBooking.Models
{
    public class Booking :BaseEntity
    {
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        //FK
        public int CustomerId { get; set; }
        public int ShowTimeId { get; set; }

        //Navigation property
        public Customer Customer { get; set; }
        public ShowTime ShowTime { get; set; }
    }
}
