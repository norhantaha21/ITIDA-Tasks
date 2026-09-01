using CinemaTicketBooking.Enums;

namespace CinemaTicketBooking.Dtos.BookingDtos
{
    public class BookingResponseDto
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string MovieName { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public DateTime ShowTime { get; set; }
    }
}
