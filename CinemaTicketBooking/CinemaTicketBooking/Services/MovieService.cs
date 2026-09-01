using AutoMapper;
using CinemaTicketBooking.Data;
using CinemaTicketBooking.Dtos.MovieDtos;
using CinemaTicketBooking.Exceptions;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;
using CinemaTicketBooking.Repository.Interface;
using CinemaTicketBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, ApplicationDbContext dbContext, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PagedResult<MovieV1Dto>> GetAllMoviesV1Async(MovieFilter filter)
        {
            var pagedResult = await _movieRepository.GetAllMoviesAsync(filter);

            return new PagedResult<MovieV1Dto>
            {
                Data = _mapper.Map<IEnumerable<MovieV1Dto>>(pagedResult.Data),
                Page = pagedResult.Page,
                PageSize = pagedResult.PageSize,
                TotalCount = pagedResult.TotalCount
            };
        }

        public async Task<PagedResult<MovieV2Dto>> GetAllMoviesV2Async(MovieFilter filter)
        {
            var pagedResult = await _movieRepository.GetAllMoviesAsync(filter);

            return new PagedResult<MovieV2Dto>
            {
                Data = _mapper.Map<IEnumerable<MovieV2Dto>>(pagedResult.Data),
                Page = pagedResult.Page,
                PageSize = pagedResult.PageSize,
                TotalCount = pagedResult.TotalCount
            };
        }

        public async Task<MovieV2Dto> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null)
                throw new MovieNotFoundException(id);

            return _mapper.Map<MovieV2Dto>(movie);
        }

        public async Task<MovieV2Dto> CreateMovieAsync(CreateUpdateMovieDto dto)
        {
            var normalizedTitle = dto.Name.Trim().ToLower();

            var exists = await _dbContext.Movies
                .AnyAsync(m => m.Name.ToLower() == normalizedTitle);

            if (exists)
                throw new MovieAlreadyExistsException(dto.Name);

            var movie = _mapper.Map<Movie>(dto);
            movie.CreatedAt = DateTime.UtcNow;

            var createdMovie = await _movieRepository.CreateMovieAsync(movie);
            return _mapper.Map<MovieV2Dto>(createdMovie);
        }

        public async Task<MovieV2Dto> UpdateMovieAsync(int id, CreateUpdateMovieDto dto)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
                throw new MovieNotFoundException(id);

            var trimmedName = dto.Name.Trim();
            if (!movie.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase))
            {
                var exists = await _dbContext.Movies
                    .AnyAsync(m => m.Name.ToLower() == trimmedName.ToLower());

                if (exists)
                    throw new MovieAlreadyExistsException(dto.Name);
            }

            _mapper.Map(dto, movie);
            movie.UpdatedAt = DateTime.UtcNow;

            var updatedMovie = await _movieRepository.UpdateMovieAsync(movie);
            return _mapper.Map<MovieV2Dto>(updatedMovie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
                throw new MovieNotFoundException(id);

            var hasActiveShowtimes = await _dbContext.ShowTimes
                .AnyAsync(s => s.MovieId == id && s.StartTime >= DateTime.UtcNow);

            if (hasActiveShowtimes)
                throw new InvalidMovieOperationException();

            return await _movieRepository.DeleteMovieAsync(id);
        }
    }
}