using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Repository
{
    public class AuditoriumRepository : IAuditoriumRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuditoriumRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Auditorium> CreateAuditoriumAsync(Auditorium auditorium)
        {
            _dbContext.Auditoriums.Add(auditorium);
            await _dbContext.SaveChangesAsync();
            return auditorium;
        }

        public async Task<bool> DeleteAuditoriumAsync(int id)
        {
            var auditorium = await _dbContext.Auditoriums.FindAsync(id);
            if (auditorium == null) return false;

            _dbContext.Auditoriums.Remove(auditorium);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Auditorium>> GetAllAuditoriumsAsync()
        {
            return await _dbContext.Auditoriums.ToListAsync();
        }

        public async Task<Auditorium?> GetByIdAsync(int id)
        {
            return await _dbContext.Auditoriums.FindAsync(id);
        }

        public async Task<Auditorium> UpdateAuditoriumAsync(Auditorium auditorium)
        {
            _dbContext.Auditoriums.Update(auditorium);
            await _dbContext.SaveChangesAsync();
            return auditorium;
        }
    }
}