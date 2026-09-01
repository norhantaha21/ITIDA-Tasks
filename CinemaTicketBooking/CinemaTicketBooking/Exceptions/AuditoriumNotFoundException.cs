using CinemaTicketBooking.Models;

namespace CinemaTicketBooking.Exceptions
{
    public class AuditoriumNotFoundException:Exception
    {
        public AuditoriumNotFoundException(int id):base($"Auditorium with ID {id} was not found") { }
    }
}
