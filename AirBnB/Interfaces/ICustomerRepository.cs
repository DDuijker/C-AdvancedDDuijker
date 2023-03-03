namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetAll();
        public Customer GetById(int id);
        public void Add(Customer customer);
        public void Update(Customer customer);
        public void Delete(int id);
        public void Save();

    }
}
