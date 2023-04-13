using AirBnB.Interfaces;
using AirBnB.Models;
using AirBnB.Models.DTO;
using AutoMapper;

namespace AirBnB.Services
{
    public class ReservationService : IReservationService
    {

        private readonly IReservationRepository _reservationRepository;
        private readonly ILocationService _locationService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, ILocationService locationService, ICustomerService customerService, IMapper mapper)
        {
            _mapper = mapper;
            _locationService = locationService;
            _customerService = customerService;
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationResponseDTO> CreateReservation(ReservationRequestDTO reservationRequestDTO, CancellationToken cancellationToken)
        {
            try
            {
                if (reservationRequestDTO == null)
                {
                    throw new ArgumentException($"Reservation needs data");
                }

                if (reservationRequestDTO.Email == null)
                {
                    throw new ArgumentException($"Reservation needs an email");
                }

                if (reservationRequestDTO.LocationId <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Location with id {reservationRequestDTO.LocationId} needs an id with a positive integer value", nameof(reservationRequestDTO.LocationId));
                }

                var customer = await _customerService.GetCustomerByEmail(reservationRequestDTO.Email, cancellationToken);
                var location = await GetLocationById(reservationRequestDTO.LocationId, cancellationToken);

                //If the customer does not exist, create a new customer
                if (customer == null)
                {
                    await _customerService.CreateCustomer(new Customer
                    {
                        Email = reservationRequestDTO.Email,
                        FirstName = reservationRequestDTO.FirstName,
                        LastName = reservationRequestDTO.LastName,
                    }, cancellationToken);

                    await _customerService.SaveChangesAsync();
                }

                var unAvailableDates = await _locationService.GetUnAvailableDates(reservationRequestDTO.LocationId, cancellationToken);

                // if the end- or startdate is in the unavailable dates, return badrequest
                foreach (var date in unAvailableDates.UnAvailableDates)
                {
                    if (reservationRequestDTO.StartDate >= date && reservationRequestDTO.StartDate <= date)
                    {
                        throw new InvalidOperationException("The location is not available for the selected dates");
                    }
                    if (reservationRequestDTO.EndDate >= date && reservationRequestDTO.EndDate <= date)
                    {
                        throw new InvalidOperationException("The location is not available for the selected dates");
                    }
                }

                var reservation = new Reservation
                {
                    StartDate = reservationRequestDTO.StartDate,
                    EndDate = reservationRequestDTO.EndDate,
                    Discount = reservationRequestDTO.Discount ??= 0,
                    Customer = customer,
                    Location = location
                };

                _reservationRepository.Add(reservation, cancellationToken);
                await _reservationRepository.SaveChangesAsync();

                //I calculated the price here for the total of days the customer is staying
                var price = location.PricePerDay * (reservation.EndDate - reservation.StartDate).Days;

                var response = new ReservationResponseDTO
                {
                    LocationName = location.Title,
                    CustomerName = customer.FirstName + " " + customer.LastName,
                    Price = price,
                    Discount = reservation.Discount,
                };

                return response;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);

            }
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations(CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetAll(cancellationToken);
        }


        public async Task<Location> GetLocationById(int id, CancellationToken cancellationToken)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), $"Location with id {id} needs an id with a positive integer value");

                }
                return await _reservationRepository.GetLocationById(id, cancellationToken);

            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        public async Task<Reservation> GetSpecificReservation(int reservationId, CancellationToken cancellationToken)
        {
            try
            {

                if (reservationId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(reservationId), $"Reservation with id {reservationId} needs an id with a positive integer value");

                }
                return await _reservationRepository.GetById(reservationId, cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public Task SaveChangesAsync()
        {
            return _reservationRepository.SaveChangesAsync();
        }

    }
}
