using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;

namespace CinemaTicketBooking.Repository.Interface
{
    public interface IBookingRepository 
    {
        Task<PagedResult<Booking>> GetAllBookingsAsync(BookingFilter filter);
        Task<Booking?> GetByIdAsync(int id);
        Task<IEnumerable<Booking>> GetByShowTimeIdAsync(int showTimeId);
        Task<IEnumerable<Booking>> GetByCustomerIdAsync(int customerId);
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(Booking booking);
    }
}
