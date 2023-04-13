using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AirBnB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ICustomerService _customerService;
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public ReservationsController(IReservationService reservation, ICustomerService customerService, ILocationService locationService, IMapper mapper)
        {
            _reservationService = reservation;
            _customerService = customerService;
            _locationService = locationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <param name="cancellationTokens">The cancellationToken token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(CancellationToken cancellationTokens)
        {
            try
            {
                var reservations = await _reservationService.GetAllReservations(cancellationTokens);
                return Ok(reservations);
            }
            catch (Exception e)
            {
                return BadRequest("While getting the reservation, something went wrong: " + e.Message);
            }


        }

        /// <summary>
        /// Get a specific reservation by the id
        /// </summary>
        /// <param name="id">The ID of the reservation</param>
        /// <param name="cancellationToken">The cancellationToken token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id, CancellationToken cancellationToken)
        {

            try
            {

                var reservation = await _reservationService.GetSpecificReservation(id, cancellationToken);

                if (reservation == null)
                {
                    return NotFound();
                }

                return Ok(reservation);

            }
            catch (Exception e)
            {
                return BadRequest("While getting the reservation, something went wrong: " + e.Message);
            }
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ReservationResponseDTO>> PostReservation(ReservationRequestDTO reservationRequestDTO, CancellationToken cancellationToken)
        {
            ReservationResponseDTO reservationResponseDTO;

            try
            {
                reservationResponseDTO = await _reservationService.CreateReservation(reservationRequestDTO, cancellationToken);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException e)
            {
                return Conflict("Er was een conflict: " + e.Message);
            }
            catch (Exception)
            {
                return BadRequest("While posting your reservation, something went wrong");
            }

            return Ok(reservationResponseDTO);
        }

    }



}
