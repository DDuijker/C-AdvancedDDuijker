
namespace AirBnB.Repositories
{
    using AirBnB.Interfaces;
    using AirBnB.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AirBnBContext _context;
        public CustomerRepository(AirBnBContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();


        }
        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
        }
        public async Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken)
        {
            return (await _context.Customers.ToListAsync(cancellationToken));
        }
        public async Task<Customer> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Customers.FindAsync(new object[] { id }, cancellationToken);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

    }
}