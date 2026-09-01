using AutoMapper;
using CinemaTicketBooking.Data;
using CinemaTicketBooking.Dtos.BookingDtos;
using CinemaTicketBooking.Enums;
using CinemaTicketBooking.Exceptions;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Filter;
using CinemaTicketBooking.Models.Pagination;
using CinemaTicketBooking.Repository.Interface;
using CinemaTicketBooking.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Services
{
    public class BookingService : IBookingService     //???
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper, ApplicationDbContext dbContext)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<BookingResponseDto> CancelBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
                throw new BookingNotFoundException(id);

            if (booking.Status == BookingStatus.Cancelled)
                throw new InvalidBookingException("Booking is already cancelled");

            booking.Status = BookingStatus.Cancelled;
            booking.UpdatedAt = DateTime.UtcNow;

            await _bookingRepository.UpdateBookingAsync(booking);
            return _mapper.Map<BookingResponseDto>(booking);
        }

        public async Task<BookingResponseDto> CreateBookingAsync(CreateBookingDto dto)
        {
            var showTime = _dbContext.ShowTimes
                .Include(s => s.Movie)
                .Include(s => s.Bookings)
                .Include(s => s.Auditorium)
                .FirstOrDefault(s => s.Id == dto.ShowTimeId);

            if (showTime == null)
                throw new ShowTimeNotFoundException(dto.ShowTimeId);

            if (!showTime.Movie.AvailableInCinema)
                throw new InvalidBookingException("Movie is not currently available in cinema");

            if (!showTime.Auditorium.Available)
                throw new InvalidBookingException("Auditorium is currently unavailable");

            var activeBookingsCount = showTime.Bookings.Count(b => b.Status != BookingStatus.Cancelled);
            if (activeBookingsCount >= showTime.Auditorium.Capacity)
                throw new InvalidBookingException("Auditorium capacity is fully booked for this showtime.");

            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Email.ToLower() == dto.CustomerEmail.Trim().ToLower());

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = dto.CustomerName.Trim(),
                    Email = dto.CustomerEmail.Trim(),
                    CreatedAt = DateTime.UtcNow
                };
                await _dbContext.Customers.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
            }

            var booking = new Booking      ///???
            {
                CustomerId = customer.Id,
                ShowTimeId = dto.ShowTimeId,
                BookingDate = DateTime.UtcNow,
                Status = BookingStatus.Confirmed,
                CreatedAt = DateTime.UtcNow
            };

            var createdBooking = await _bookingRepository.CreateBookingAsync(booking);
            var loadedBooking = await _bookingRepository.GetByIdAsync(createdBooking.Id);

            return _mapper.Map<BookingResponseDto>(loadedBooking);
        }

        public async Task<PagedResult<BookingResponseDto>> GetAllBookingsAsync(BookingFilter filter)
        {
           var bookings=await _bookingRepository.GetAllBookingsAsync(filter);
            return new PagedResult<BookingResponseDto>
            {
                Data = _mapper.Map<IEnumerable<BookingResponseDto>>(bookings.Data),
                Page = bookings.Page,
                PageSize = bookings.PageSize,
                TotalCount = bookings.TotalCount
            };

        }

        public async Task<BookingResponseDto> GetBookingByIdAsync(int id)
        {
            var check=await _bookingRepository.GetByIdAsync(id);

            if(check==null) throw new BookingNotFoundException(id);

            return _mapper.Map<BookingResponseDto>(check);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingsByCustomerIdAsync(int customerId)
        {
            var customerExists = await _dbContext.Customers.AnyAsync(c => c.Id == customerId);
            if (!customerExists)
                throw new CustomerNotFoundException(customerId);

            var bookings = await _bookingRepository.GetByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<BookingResponseDto>>(bookings);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingsByShowTimeIdAsync(int showTimeId)
        {
           var ShowtimeExists=await _dbContext.ShowTimes.AnyAsync(a=>a.Id == showTimeId);
            if(!ShowtimeExists) 
                throw new ShowTimeNotFoundException(showTimeId);

            var bookings = await _bookingRepository.GetByShowTimeIdAsync(showTimeId);
            return _mapper.Map<IEnumerable<BookingResponseDto>>(bookings);
        }
    }
}
