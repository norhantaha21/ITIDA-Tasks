using CinemaTicketBooking.Data;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email.ToLower() == email.Trim().ToLower());
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }
    }
}
