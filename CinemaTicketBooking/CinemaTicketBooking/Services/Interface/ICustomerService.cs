using CinemaTicketBooking.Dtos.CustomerDtos;

namespace CinemaTicketBooking.Services.Interface
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetByIdAsync(int id);
        Task<CustomerDto> GetByEmailAsync(string email);
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto dto);
    }
}
