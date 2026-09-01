using CinemaTicketBooking.Models.Pagination;

namespace CinemaTicketBooking.Models.Filter
{
    public class MovieFilter:PaginationParam
    {
        public string? Search { get; set; }     
        public string? Genre { get; set; }    
        public string? SortBy { get; set; }   
        public string? Order { get; set; } = "asc";

    }
}
