using AirBnB.Models;

namespace AirBnB.Services
{
    public interface IReservationService
    {
        public Task<Customer> GetCustomerByEmail(string email, CancellationToken cancellationToken);

        public Task<Location> GetLocationById(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<Reservation>> GetAllReservations(CancellationToken cancellationToken);
        public Task<Reservation> GetSpecificReservation(int reservationId, CancellationToken cancellationToken);

        public bool CreateReservation(Reservation reservation, CancellationToken cancellationToken);
        public Task SaveChangesAsync();
    }
}
