using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Repository
{
    public class ShowTimeRepository:IShowTimeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShowTimeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShowTime> CreateShowTimeAsync(ShowTime showTime)
        {
            await _dbContext.ShowTimes.AddAsync(showTime);
            await _dbContext.SaveChangesAsync();
            return showTime;
        }

        public async Task<bool> DeleteShowTimeAsync(int id)
        {
            var showTime = await _dbContext.ShowTimes.FindAsync(id);
            if (showTime == null) return false;

            _dbContext.ShowTimes.Remove(showTime);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ShowTime>> GetAllAsync()
        {
               return await _dbContext.ShowTimes
                .Include(s => s.Movie)
                .Include(s => s.Auditorium)
                .OrderBy(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<ShowTime>> GetByAuditoriumAndDateAsync(int auditoriumId, DateTime? date = null)
        {
            var query = _dbContext.ShowTimes
                .Include(s => s.Movie)
                .Include(s => s.Auditorium)
                .Where(s => s.AuditoriumId == auditoriumId);

            if (date.HasValue)
            {
                var targetDate = date.Value.Date;
                query = query.Where(s => s.StartTime.Date == targetDate);
            }

            return await query.OrderBy(s => s.StartTime).ToListAsync();
        }

        public async Task<ShowTime?> GetByIdAsync(int id)
        {
            return await _dbContext.ShowTimes
                .Include(s => s.Movie)
                .Include(s => s.Auditorium)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<ShowTime>> GetByMovieIdAsync(int movieId)
        {
            return await _dbContext.ShowTimes
                .Include(s => s.Movie)    
                .Include(s => s.Auditorium)  
                .Where(s => s.MovieId == movieId)
                .OrderBy(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<ShowTime> UpdateShowTimeAsync(ShowTime showTime)
        {
            _dbContext.ShowTimes.Update(showTime);
            await _dbContext.SaveChangesAsync();
            return showTime;
        }
    }
}
