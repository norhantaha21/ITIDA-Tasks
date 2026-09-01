namespace CinemaTicketBooking.Exceptions
{
    public class MovieAlreadyExistsException : Exception
    {
        public MovieAlreadyExistsException(string name) : base($"Movie with title '{name}' already exists.") { }
    }
}
