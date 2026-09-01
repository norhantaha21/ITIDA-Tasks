using AutoMapper;
using CinemaTicketBooking.Data;
using CinemaTicketBooking.Dtos.AudiotoriumDtos;
using CinemaTicketBooking.Exceptions;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Repository.Interface;
using CinemaTicketBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Services
{
    public class AuditoriumService : IAuditoriumService
    {
        private readonly IAuditoriumRepository _auditoriumRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuditoriumService(IAuditoriumRepository auditoriumRepository, ApplicationDbContext dbContext, IMapper mapper)
        {
            _auditoriumRepository = auditoriumRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AuditoriumDto> CreateAuditoriumAsync(CreateUpdateAuditoriumDto dto)
        {
            var exist = _dbContext.Auditoriums
                .Any(c => c.RoomNumber == dto.RoomNumber);

            if (exist)
                throw new InvalidOperationException(
                    $"Auditorium '{dto.RoomNumber}' already exists.");

            var auditorium = _mapper.Map<Auditorium>(dto);

            auditorium.CreatedAt = DateTime.UtcNow;

            var createdAuditorium =
                await _auditoriumRepository.CreateAuditoriumAsync(auditorium);

            return _mapper.Map<AuditoriumDto>(createdAuditorium);
        }

        public async Task<bool> DeleteAuditoriumAsync(int id)
        {
            var auditorium = await _auditoriumRepository.GetByIdAsync(id);
            if (auditorium == null)
                throw new AuditoriumNotFoundException(id);

            var hasShows = await _dbContext.ShowTimes.AnyAsync(s => s.AuditoriumId == id);
            if (hasShows)
                throw new InvalidOperationException("Cannot delete auditorium with scheduled showtimes");

            return await _auditoriumRepository.DeleteAuditoriumAsync(id);
        }

        public async Task<IEnumerable<AuditoriumDto>> GetAllAuditoriumAsync()
        {
            var auditoriums =await _auditoriumRepository.GetAllAuditoriumsAsync();
            return  _mapper.Map<IEnumerable<AuditoriumDto>>(auditoriums);
        }

        public async Task<AuditoriumDto> GetAuditoriumByIdAsync(int id)
        {
            var check=await _auditoriumRepository.GetByIdAsync(id);

            if (check == null) throw new AuditoriumNotFoundException(id);

            return _mapper.Map<AuditoriumDto>(check);
        }

        public async Task<AuditoriumDto> UpdateAuditoriumAsync(int id, CreateUpdateAuditoriumDto dto)
        {
            var auditorium = await _auditoriumRepository.GetByIdAsync(id);

            if (auditorium == null)
                throw new AuditoriumNotFoundException(id);

            if (auditorium.RoomNumber != dto.RoomNumber)
            {
                var exists = await _dbContext.Auditoriums
                    .AnyAsync(a => a.RoomNumber == dto.RoomNumber);

                if (exists)
                    throw new InvalidOperationException(
                        $"Auditorium '{dto.RoomNumber}' already exists");
            }

            _mapper.Map(dto, auditorium);

            auditorium.UpdatedAt = DateTime.UtcNow;

            var updatedAuditorium =
                await _auditoriumRepository.UpdateAuditoriumAsync(auditorium);

            return _mapper.Map<AuditoriumDto>(updatedAuditorium);
        }
    }
}
