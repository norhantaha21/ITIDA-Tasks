namespace CinemaTicketBooking.Exceptions
{
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException(int id) : base($"Booking with Id '{id}' was not found") { }
    }
}
