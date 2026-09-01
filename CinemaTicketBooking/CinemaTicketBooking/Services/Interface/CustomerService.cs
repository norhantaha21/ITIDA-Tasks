using AutoMapper;
using CinemaTicketBooking.Dtos.CustomerDtos;
using CinemaTicketBooking.Exceptions;
using CinemaTicketBooking.Models;
using CinemaTicketBooking.Repository.Interface;

namespace CinemaTicketBooking.Services.Interface
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var existingCustomer = await _customerRepository.GetByEmailAsync(dto.Email);
            if (existingCustomer != null)
                return _mapper.Map<CustomerDto>(existingCustomer);

            var customer = _mapper.Map<Customer>(dto);
            customer.CreatedAt = DateTime.UtcNow;

            var createdCustomer = await _customerRepository.CreateCustomerAsync(customer);
            return _mapper.Map<CustomerDto>(createdCustomer);
        }

        public async Task<CustomerDto> GetByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            if (customer == null)
                throw new InvalidOperationException($"Customer with email '{email}' was not found");

            return _mapper.Map<CustomerDto>(customer);

        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new CustomerNotFoundException(id);

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
