using AirBnB.Models;
using AirBnB.Models.DTO;

namespace AirBnB.Services
{
    public interface IReservationService
    {
        public Task<Location> GetLocationById(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<Reservation>> GetAllReservations(CancellationToken cancellationToken);
        public Task<Reservation> GetSpecificReservation(int reservationId, CancellationToken cancellationToken);

        public Task<ReservationResponseDTO> CreateReservation(ReservationRequestDTO reservationRequestDTO, CancellationToken cancellationToken);
        public Task SaveChangesAsync();
    }
}
