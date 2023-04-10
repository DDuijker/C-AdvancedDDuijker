using AirBnB.Interfaces;
using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public ReservationsController(IReservationService reservation, ICustomerRepository customerRepository, ILocationService locationService, IMapper mapper)
        {
            _reservationService = reservation;
            _customerRepository = customerRepository;
            _locationService = locationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <param name="cancellationTokens">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(CancellationToken cancellationTokens)
        {
            var reservations = await _reservationService.GetAllReservations(cancellationTokens);
            return Ok(reservations);
        }

        /// <summary>
        /// Get a specific reservation by the id
        /// </summary>
        /// <param name="id">The ID of the reservation</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id, CancellationToken cancellationToken)
        {
            var reservation = await _reservationService.GetSpecificReservation(id, cancellationToken);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }



        /// <summary>
        /// Check if a reservation exists
        /// </summary>
        /// <param name="reservationRequestDTO">The request in DTO form, as follows:
        /// {
        ///"StartDate": DateTime,
        ///"EndDate": DateTime,
        ///"LocationId": int,
        ///"Discount": float?, // optioneel
        ///"Email": string,
        ///"FirstName": string,
        ///"LastName": string
        ///  }
        /// </param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ReservationResponseDTO>> PostReservation(ReservationRequestDTO reservationRequestDTO, CancellationToken cancellation)
        {
            //get customer by email
            var customer = await _reservationService.GetCustomerByEmail(reservationRequestDTO.Email, cancellation);

            var location = await _reservationService.GetLocationById(reservationRequestDTO.LocationId, cancellation);

            // if customer doesn't exist, create new customer
            if (customer == null)
            {
                customer = new Customer
                {
                    Email = reservationRequestDTO.Email,
                    FirstName = reservationRequestDTO.FirstName,
                    LastName = reservationRequestDTO.LastName
                };

                _customerRepository.Add(customer);
                await _customerRepository.SaveChangesAsync();
            }

            var unAvailable = await _locationService.GetUnAvailableDates(reservationRequestDTO.LocationId, cancellation);

            foreach (var date in unAvailable.UnAvailableDates)
            {
                // if the startdate is between the unavailable dates, return badrequest
                if (reservationRequestDTO.StartDate >= date && reservationRequestDTO.StartDate <= date)
                {
                    return BadRequest("Location is not available on this date");
                }

                // if the enddate is between the unavailable dates, return badrequest
                if (reservationRequestDTO.EndDate >= date && reservationRequestDTO.EndDate <= date)
                {
                    return BadRequest("Location is not available on this date");
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

            if (reservation.StartDate < DateTime.Now || reservation.EndDate < DateTime.Now)
            {
                return BadRequest("Start and end date must be in the future");
            }

            if (reservation.StartDate > reservation.EndDate)
            {
                return BadRequest("Start date must be before end date");
            }

            try
            {
                _reservationService.CreateReservation(reservation, cancellation);
                await _reservationService.SaveChangesAsync();
                var price = location.PricePerDay * (reservation.EndDate - reservation.StartDate).Days;


                var response = new ReservationResponseDTO
                {
                    LocationName = location.Title,
                    CustomerName = customer.FirstName + " " + customer.LastName,
                    Price = price,
                    Discount = reservation.Discount
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("While posting your reservation, something went wrong");
            }
        }

    }



}
