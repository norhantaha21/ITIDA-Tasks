using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;
using CinemaTicketBooking.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public MovieRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            _dbcontext.Movies.Add(movie);
            await _dbcontext.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _dbcontext.Movies.FindAsync(id);
            if (movie == null) return false;

            _dbcontext.Movies.Remove(movie);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResult<Movie>> GetAllMoviesAsync(MovieFilter filter)
        {
            var movies = _dbcontext.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                movies = movies.Where(p => p.Name.Contains(filter.Search, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(filter.Genre)) { 
                movies = movies.Where(p => p.Genre.Contains(filter.Genre, StringComparison.OrdinalIgnoreCase)); }

            var allowedSort = new Dictionary<string, Expression<Func<Movie, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Name"] = m => m.Name,
                ["Genre"] = m => m.Genre,
                ["ReleaseDate"] = m => m.ReleaseDate
            };

            var sortBy = filter.SortBy ?? "Name";

            if (allowedSort.TryGetValue(sortBy, out var keySelector))
            {
                var isDesc = filter.Order?.ToLower() == "desc";

                movies = isDesc
                    ? movies.OrderByDescending(keySelector)
                    : movies.OrderBy(keySelector);
            }

            var totalCount = await movies.CountAsync();
            var items = await movies
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<Movie>
            {
                Data = movies,
                Page = filter.Page,
                PageSize = filter.PageSize,
                TotalCount = _dbcontext.Movies.Count()
            };
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _dbcontext.Movies.FindAsync(id);
        }


        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            _dbcontext.Movies.Update(movie);
            await _dbcontext.SaveChangesAsync();
            return movie;
        }
    }
}
