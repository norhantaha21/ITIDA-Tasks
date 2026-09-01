using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;

namespace CinemaTicketBooking.Repository.Interface
{
    public interface IMovieRepository 
    {
        Task<PagedResult<Movie>> GetAllMoviesAsync(MovieFilter filter);
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
    }
}
