using AirBnB.Models;
using AirBnB.Models.DTO;

namespace AirBnB.Services
{
    public interface ICustomerService
    {
        public Task<IEnumerable<CustomerResponseDTO>> GetAllCustomers(CancellationToken cancellationToken);
        public Task<Customer> GetCustomerById(int id, CancellationToken cancellationToken);
        public Task<Customer> GetCustomerByEmail(string email, CancellationToken cancellationToken);
        public Task<CustomerResponseDTO> CreateCustomer(CustomerRequestDTO customerRequestDTO, CancellationToken cancellationToken);
        public Task SaveChangesAsync();
    }
}
