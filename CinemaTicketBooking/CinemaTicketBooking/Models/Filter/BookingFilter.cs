using CinemaTicketBooking.Enums;
using CinemaTicketBooking.Models.Pagination;

namespace CinemaTicketBooking.Models.Filter
{
    public class BookingFilter :PaginationParam
    {
        public int? CustomerId { get; set; } 
        public string? CustomerName { get; set; }  
        public int? ShowTimeId { get; set; } 
        public BookingStatus? Status { get; set; }
    }
}
