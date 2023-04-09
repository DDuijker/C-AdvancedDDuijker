namespace AirBnB.Repositories
{
    using AirBnB.Interfaces;
    using AirBnB.Models;
    using Microsoft.EntityFrameworkCore;

    public class ReservationRepository : IReservationRepository
    {
        private readonly AirBnBContext _context;



        public ReservationRepository(AirBnBContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByEmail(string email, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
            return customer;
        }

        public async Task<Location> GetLocationById(int id, CancellationToken cancellationToken)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
            return location;
        }

        public void Add(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
        }

        public void Delete(int id)
        {
            var reservation = _context.Reservations.Find(id);
            _context.Reservations.Remove(reservation);
        }

        public async Task<IEnumerable<Reservation>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Reservations.ToListAsync(cancellationToken);
        }

        public async Task<Reservation> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Reservations.FindAsync(new object[] { id }, cancellationToken);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
        }
    }
}
