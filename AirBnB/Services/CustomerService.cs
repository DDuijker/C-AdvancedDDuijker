using AirBnB.Interfaces;
using AirBnB.Models;
using AirBnB.Models.DTO;
using AutoMapper;
namespace AirBnB.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> CreateCustomer(Customer customer, CancellationToken cancellationToken)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException(nameof(customer), "Customer object cannot be null.");
                }
                _customerRepository.Add(customer);
                await _customerRepository.SaveChangesAsync();
                return customer;

            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while creating the customer.", e);
            }



        }

        //Get all customers in a nice formatted response, custom made
        public async Task<IEnumerable<CustomerResponseDTO>> GetAllCustomers(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll(cancellationToken);
            return customers.Select(customer => _mapper.Map<Customer, CustomerResponseDTO>(customer));


        }

        public async Task<Customer> GetCustomerByEmail(string email, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByEmail(email, cancellationToken);
            return customer;

        }

        public async Task<Customer> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "Customer ID must be a positive integer.");
                }

                var customer = await _customerRepository.GetById(id, cancellationToken);

                if (customer == null)
                {
                    throw new ArgumentException($"Customer with ID {id} does not exist.", nameof(id));
                }

                return customer;
            }
            catch (Exception ex)
            {
                // Log the error message here or throw a custom exception if needed.
                throw new Exception("An error occurred while getting the customer by ID.", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _customerRepository.SaveChangesAsync();
        }
    }
}
