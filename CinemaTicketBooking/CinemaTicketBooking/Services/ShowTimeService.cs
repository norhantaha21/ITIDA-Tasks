using AutoMapper;
using CinemaTicketBooking.Data;
using CinemaTicketBooking.Dtos.ShowTimeDtos;
using CinemaTicketBooking.Exceptions;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Repository;
using CinemaTicketBooking.Repository.Interface;
using CinemaTicketBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Services
{
    public class ShowTimeService:IShowTimeService
    {
        private readonly IShowTimeRepository _showTimeRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ShowTimeService(
            IShowTimeRepository showTimeRepository,
            ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _showTimeRepository = showTimeRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ShowTimeResponseDto> CreateShowTimeAsync(CreateUpdateShowTimeDto dto)
        {
            var movie = await _dbContext.Movies.FindAsync(dto.MovieId);
            if (movie == null)
                throw new MovieNotFoundException(dto.MovieId);

            if (!movie.AvailableInCinema)
                throw new InvalidBookingException("Cannot schedule a showtime for a movie that is not available in cinema");

            var auditorium = await _dbContext.Auditoriums.FindAsync(dto.AuditoriumId);
            if (auditorium == null)
                throw new AuditoriumNotFoundException(dto.AuditoriumId);

            if (!auditorium.Available)
                throw new InvalidBookingException("Cannot schedule a showtime in an unavailable auditorium");

            var showTime = _mapper.Map<ShowTime>(dto);
            showTime.CreatedAt = DateTime.UtcNow;

            var createdShowTime = await _showTimeRepository.CreateShowTimeAsync(showTime);
            var loadedShowTime = await _showTimeRepository.GetByIdAsync(createdShowTime.Id);

            return _mapper.Map<ShowTimeResponseDto>(loadedShowTime);
        }

        public async Task<bool> DeleteShowTimeAsync(int id)
        {
            var showTime = await _showTimeRepository.GetByIdAsync(id);
            if (showTime == null)
                throw new ShowTimeNotFoundException(id);

            var hasActiveBookings = await _dbContext.Bookings.AnyAsync(b => b.ShowTimeId == id && b.Status != Enums.BookingStatus.Cancelled);
            if (hasActiveBookings)
                throw new InvalidOperationException("Cannot delete showtime with active bookings");

            return await _showTimeRepository.DeleteShowTimeAsync(id);
        }

        public async Task<IEnumerable<ShowTimeResponseDto>> GetAllAsync()
        {
            var showtimes=await _showTimeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShowTimeResponseDto>>(showtimes);
        }

        public async Task<IEnumerable<ShowTimeResponseDto>> GetByAuditoriumAndDateAsync(int auditoriumId, DateTime? date = null)
        {
            var audiotorium =  _dbContext.Auditoriums.Any(c=>c.Id == auditoriumId);
            if (!audiotorium)
                throw new AuditoriumNotFoundException(auditoriumId);

            var showTimes = await _showTimeRepository.GetByAuditoriumAndDateAsync(auditoriumId, date);
            return _mapper.Map<IEnumerable<ShowTimeResponseDto>>(showTimes);
        }

        public async Task<ShowTimeResponseDto> GetByIdAsync(int id)
        {
            var showTime = await _showTimeRepository.GetByIdAsync(id);
            if (showTime == null)
                throw new ShowTimeNotFoundException(id);

            return _mapper.Map<ShowTimeResponseDto>(showTime);
        }

        public async Task<IEnumerable<ShowTimeResponseDto>> GetByMovieIdAsync(int movieId)
        {
            var movieExists = await _dbContext.Movies.AnyAsync(m => m.Id == movieId);
            if (!movieExists)
                throw new MovieNotFoundException(movieId);

            var showTimes = await _showTimeRepository.GetByMovieIdAsync(movieId);
            return _mapper.Map<IEnumerable<ShowTimeResponseDto>>(showTimes);
        }

        public async Task<ShowTimeResponseDto> UpdateShowTimeAsync(int id, CreateUpdateShowTimeDto dto)
        {
            var existingShowTime = await _showTimeRepository.GetByIdAsync(id);
            if (existingShowTime == null)
                throw new ShowTimeNotFoundException(id);

            var movie = await _dbContext.Movies.FindAsync(dto.MovieId);
            if (movie == null)
                throw new MovieNotFoundException(dto.MovieId);

            if (!movie.AvailableInCinema)
                throw new InvalidBookingException("Cannot schedule a showtime for a movie that is not available in cinema");

            var auditorium = await _dbContext.Auditoriums.FindAsync(dto.AuditoriumId);
            if (auditorium == null)
                throw new AuditoriumNotFoundException(dto.AuditoriumId);

            if (!auditorium.Available)
                throw new InvalidBookingException("Cannot schedule a showtime in an unavailable auditorium");

            _mapper.Map(dto, existingShowTime);
            existingShowTime.UpdatedAt = DateTime.UtcNow;

            await _showTimeRepository.UpdateShowTimeAsync(existingShowTime);
            var loadedShowTime = await _showTimeRepository.GetByIdAsync(id);

            return _mapper.Map<ShowTimeResponseDto>(loadedShowTime);
        }
    }
}
