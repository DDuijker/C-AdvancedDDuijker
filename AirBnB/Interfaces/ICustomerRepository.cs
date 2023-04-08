namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken);
        public Task<Customer> GetById(int id, CancellationToken cancellationToken);
        public void Add(Customer customer);
        public void Update(Customer customer);
        public void Delete(int id);
        public void Save();
        Task SaveChangesAsync();
    }
}
