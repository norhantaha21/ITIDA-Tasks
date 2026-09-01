using CinemaTicketBooking.Dtos.AudiotoriumDtos;
using CinemaTicketBooking.Models;

namespace CinemaTicketBooking.Services.Interface
{
    public interface IAuditoriumService
    {
        Task<IEnumerable<AuditoriumDto>> GetAllAuditoriumAsync();
        Task<AuditoriumDto> GetAuditoriumByIdAsync(int id);
        Task<AuditoriumDto> CreateAuditoriumAsync(CreateUpdateAuditoriumDto dto);
        Task<AuditoriumDto> UpdateAuditoriumAsync(int id, CreateUpdateAuditoriumDto dto);
        Task<bool> DeleteAuditoriumAsync(int id);
    }
}
