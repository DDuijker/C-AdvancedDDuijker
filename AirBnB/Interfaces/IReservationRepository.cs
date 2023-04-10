namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface IReservationRepository
    {
        public Task<IEnumerable<Reservation>> GetAll(CancellationToken cancellationToken);
        public Task<Reservation> GetById(int id, CancellationToken cancellationToken);
        void Add(Reservation reservation, CancellationToken cancellationToken);
        void Save();
        Task<Customer> GetCustomerByEmail(string email, CancellationToken cancellationToken);
        Task<Location> GetLocationById(int id, CancellationToken cancellationToken);
        public Task SaveChangesAsync();
    }
}
