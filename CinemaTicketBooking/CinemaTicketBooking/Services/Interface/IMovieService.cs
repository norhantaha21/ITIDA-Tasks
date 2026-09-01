using CinemaTicketBooking.Dtos.MovieDtos;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;

namespace CinemaTicketBooking.Services.Interface
{
    public interface IMovieService
    {
        Task<PagedResult<MovieV1Dto>> GetAllMoviesV1Async(MovieFilter filter);
        Task<PagedResult<MovieV2Dto>> GetAllMoviesV2Async(MovieFilter filter);
        Task<MovieV2Dto> GetMovieByIdAsync(int id);
        Task<MovieV2Dto> CreateMovieAsync(CreateUpdateMovieDto dto);
        Task<MovieV2Dto> UpdateMovieAsync(int id, CreateUpdateMovieDto dto);
        Task<bool> DeleteMovieAsync(int id);
    }
}
