using AirBnB.Interfaces;
using AirBnB.Models;
using AirBnB.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationsController(IReservationRepository repository)
        {
            _reservationRepository = repository;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <param name="cancellationTokens">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(CancellationToken cancellationTokens)
        {
            var reservations = await _reservationRepository.GetAll(cancellationTokens);
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
            var reservation = await _reservationRepository.GetById(id, cancellationToken);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        /// <summary>
        /// Update a reservation
        /// </summary>
        /// <param name="id">The id of the reservation you want to edit</param>
        /// <param name="reservation">The new reservation data</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation, CancellationToken cancellationToken)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _reservationRepository.Update(reservation);

            try
            {
                await _reservationRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id, cancellationToken))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
            var customer = await _reservationRepository.GetCustomerByEmail(reservationRequestDTO.Email, cancellation);

            var location = await _reservationRepository.GetLocationById(reservationRequestDTO.LocationId, cancellation);

            var reservation = new Reservation
            {
                StartDate = reservationRequestDTO.StartDate,
                EndDate = reservationRequestDTO.EndDate,
                Discount = reservationRequestDTO.Discount ??= 0,
                Customer = customer,
                Location = location
            };

            _reservationRepository.Add(reservation);
            await _reservationRepository.SaveChangesAsync();

            var price = location.PricePerDay * (reservation.EndDate - reservation.StartDate).Days;
            var newPrice = price - (price * reservation.Discount / 100);

            var response = new ReservationResponseDTO
            {
                LocationName = location.Title,
                CustomerName = customer.FirstName + " " + customer.LastName,
                Price = newPrice,
                Discount = reservation.Discount
            };

            return response;
        }


        /// <summary>
        /// Delete a reservation
        /// </summary>
        /// <param name="id">The id of the reservation you want to delete</param>
        /// <param name="cancellationtoken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id, CancellationToken cancellationtoken)
        {
            var reservation = await _reservationRepository.GetById(id, cancellationtoken);
            if (reservation == null)
            {
                return NotFound();
            }

            _reservationRepository.Delete(id);
            await _reservationRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Check if the reservation exists
        /// </summary>
        /// <param name="id">the id of the reservation you want to check</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        private bool ReservationExists(int id, CancellationToken cancellationToken)
        {
            return _reservationRepository.GetById(id, cancellationToken) != null;
        }
    }
}
