using CinemaTicketBooking.Dtos.ShowTimeDtos;

namespace CinemaTicketBooking.Services.Interface
{
    public interface IShowTimeService
    {
        Task<IEnumerable<ShowTimeResponseDto>> GetAllAsync();
        Task<ShowTimeResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<ShowTimeResponseDto>> GetByMovieIdAsync(int movieId);
        Task<IEnumerable<ShowTimeResponseDto>> GetByAuditoriumAndDateAsync(int auditoriumId, DateTime? date = null);
        Task<ShowTimeResponseDto> CreateShowTimeAsync(CreateUpdateShowTimeDto dto);
        Task<ShowTimeResponseDto> UpdateShowTimeAsync(int id, CreateUpdateShowTimeDto dto);
        Task<bool> DeleteShowTimeAsync(int id);
    }
}
