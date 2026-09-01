using CinemaTicketBooking.Models;

namespace CinemaTicketBooking.Repository.Interface
{
    public interface IAuditoriumRepository
    {
        Task<IEnumerable<Auditorium>> GetAllAuditoriumsAsync();
        Task<Auditorium?> GetByIdAsync(int id);
        Task<Auditorium> CreateAuditoriumAsync(Auditorium auditorium);
        Task<Auditorium> UpdateAuditoriumAsync(Auditorium auditorium);
        Task<bool> DeleteAuditoriumAsync(int id);
    }
}
