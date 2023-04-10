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

        public async Task<CustomerResponseDTO> CreateCustomer(CustomerRequestDTO customerRequestDTO, CancellationToken cancellationToken)
        {
            var customerExists = await _customerRepository.GetByEmail(customerRequestDTO.Email, cancellationToken);
            if (customerExists != null)
            {
                return null;
            }

            Customer customer = new()
            {
                Email = customerRequestDTO.Email,
                FirstName = customerRequestDTO.FirstName,
                LastName = customerRequestDTO.LastName,
            };

            _customerRepository.Add(customer);
            await _customerRepository.SaveChangesAsync();
            return _mapper.Map<Customer, CustomerResponseDTO>(customer);
        }

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
            var customer = await _customerRepository.GetById(id, cancellationToken);
            return customer;

        }

        public async Task SaveChangesAsync()
        {
            await _customerRepository.SaveChangesAsync();
        }
    }
}
