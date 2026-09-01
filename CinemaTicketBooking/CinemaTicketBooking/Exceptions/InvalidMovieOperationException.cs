namespace CinemaTicketBooking.Exceptions
{
    public class InvalidMovieOperationException :Exception
    {
        public InvalidMovieOperationException():base("Cannot delete a movie with active or future showtimes") { }
    }
}
