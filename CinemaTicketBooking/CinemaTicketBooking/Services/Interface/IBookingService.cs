using CinemaTicketBooking.Dtos.BookingDtos;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;

namespace CinemaTicketBooking.Services.Interface
{
    public interface IBookingService
    {
        Task<PagedResult<BookingResponseDto>> GetAllBookingsAsync(BookingFilter filter);
        Task<BookingResponseDto> GetBookingByIdAsync(int id);
        Task<IEnumerable<BookingResponseDto>> GetBookingsByCustomerIdAsync(int customerId);
        Task<IEnumerable<BookingResponseDto>> GetBookingsByShowTimeIdAsync(int showTimeId);
        Task<BookingResponseDto> CreateBookingAsync(CreateBookingDto dto);
        Task<BookingResponseDto> CancelBookingAsync(int id);
    }
}
