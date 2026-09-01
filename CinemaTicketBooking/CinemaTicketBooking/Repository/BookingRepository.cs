using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;
using CinemaTicketBooking.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Repository
{
    public class BookingRepository : IBookingRepository   
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync();
            return booking;
        }

        public async Task<PagedResult<Booking>> GetAllBookingsAsync(BookingFilter filter)       
        {
            var query = _dbContext.Bookings
                .Include(b => b.Customer)
                .Include(b => b.ShowTime)
                    .ThenInclude(s => s.Movie)
                .Include(b => b.ShowTime)
                    .ThenInclude(s => s.Auditorium)
                .AsQueryable();

            if (filter.CustomerId.HasValue)
                query = query.Where(b => b.CustomerId == filter.CustomerId.Value);

            if (!string.IsNullOrWhiteSpace(filter.CustomerName))
                query = query.Where(b => b.Customer.Name.ToLower().Contains(filter.CustomerName.Trim().ToLower()));

            if (filter.ShowTimeId.HasValue)
                query = query.Where(b => b.ShowTimeId == filter.ShowTimeId.Value);

            if (filter.Status.HasValue)
                query = query.Where(b => b.Status == filter.Status.Value);

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(b => b.BookingDate)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<Booking>
            {
                Data = query,
                Page = filter.Page,
                PageSize = filter.PageSize,
                TotalCount = _dbContext.Bookings.Count()
            };
        }

        public async Task<IEnumerable<Booking>> GetByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Bookings
           .Include(b => b.Customer)
           .Include(b => b.ShowTime)
               .ThenInclude(s => s.Movie)
           .Include(b => b.ShowTime)
               .ThenInclude(s => s.Auditorium)
           .Where(b => b.CustomerId == customerId)
           .ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)  
        {
            return await _dbContext.Bookings
                .Include(b => b.Customer)
                .Include(b => b.ShowTime)
                    .ThenInclude(s => s.Movie)
                .Include(b => b.ShowTime)
                    .ThenInclude(s => s.Auditorium)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetByShowTimeIdAsync(int showTimeId)
        {
            return await _dbContext.Bookings
                .Include(b => b.Customer)
                .Include(b => b.ShowTime)
                    .ThenInclude(s => s.Movie)
                .Include(b => b.ShowTime)
                    .ThenInclude(s => s.Auditorium)
                .Where(b => b.ShowTimeId == showTimeId)
                .ToListAsync();
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            _dbContext.Bookings.Update(booking);
            await _dbContext.SaveChangesAsync();
            return booking;
        }
    }
}
