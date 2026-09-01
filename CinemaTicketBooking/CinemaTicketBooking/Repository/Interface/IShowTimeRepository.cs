using CinemaTicketBooking.Models;

namespace CinemaTicketBooking.Repository.Interface
{
    public interface IShowTimeRepository 
    {
        Task<IEnumerable<ShowTime>> GetAllAsync();
        Task<ShowTime?> GetByIdAsync(int id);
        Task<IEnumerable<ShowTime>> GetByMovieIdAsync(int movieId);
        Task<IEnumerable<ShowTime>> GetByAuditoriumAndDateAsync(int auditoriumId, DateTime? date = null);
        Task<ShowTime> CreateShowTimeAsync(ShowTime showTime);
        Task<ShowTime> UpdateShowTimeAsync(ShowTime showTime);
        Task<bool> DeleteShowTimeAsync(int id);
    }
}
