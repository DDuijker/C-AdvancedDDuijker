using AirBnB.Interfaces;
using AirBnB.Models;
using AutoMapper;

namespace AirBnB.Services
{
    public class ReservationService : IReservationService
    {

        private readonly IReservationRepository _reservationRepository;

        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }
        public bool CreateReservation(Reservation reservation, CancellationToken cancellationToken)
        {
            try
            {
                _reservationRepository.Add(reservation, cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations(CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetAll(cancellationToken);
        }

        public async Task<Customer> GetCustomerByEmail(string email, CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetCustomerByEmail(email, cancellationToken);
        }

        public async Task<Location> GetLocationById(int id, CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetLocationById(id, cancellationToken);
        }

        public async Task<Reservation> GetSpecificReservation(int reservationId, CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetById(reservationId, cancellationToken);
        }

        public Task SaveChangesAsync()
        {
            return _reservationRepository.SaveChangesAsync();
        }

    }
}
