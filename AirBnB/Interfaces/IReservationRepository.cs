namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface IReservationRepository
    {
        public Task<Customer> GetCustomerByEmail(string email, CancellationToken cancellationToken);
        public Task<Location> GetLocationById(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<Reservation>> GetAll(CancellationToken cancellationToken);
        public Task<Reservation> GetById(int id, CancellationToken cancellationToken);
        void Add(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int id);
        void Save();

        public Task SaveChangesAsync();
    }
}
