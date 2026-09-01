using CinemaTicketBooking.Models;

namespace CinemaTicketBooking.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetByEmailAsync(string email);
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
