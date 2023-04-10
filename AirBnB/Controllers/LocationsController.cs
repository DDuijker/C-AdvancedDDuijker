using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AirBnB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]

    public class LocationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a collection of unavailable dates for a specific location.
        /// </summary>
        /// <param name="locationId">The ID of the location for which the unavailable dates are being retrieved.</param>
        /// <param name="cancellationToken">A token used to cancel the operation if required.</param>
        /// <returns>
        /// An HTTP response containing the collection of UnAvailableDatesDTO objects for the specified location ID.
        /// The method returns a "404 Not Found" response if no unavailable dates are found for the specified location ID.
        /// </returns>
        [HttpGet]
        [Route("UnavailableDates/{locationId}")]
        public async Task<ActionResult<IEnumerable<UnAvailableDatesDTO>>> GetUnavailableDates(int locationId, CancellationToken cancellationToken)
        {

            try
            {
                var unavailableDates = await _locationService.GetUnAvailableDates(locationId, cancellationToken);

                if (unavailableDates == null)
                {
                    return NotFound();
                }

                return Ok(unavailableDates);
            }
            catch (Exception e)
            {
                return BadRequest("While trying to get all the unavailable dates, something went wrong: " + e.Message);
            }


        }


        /// <summary>
        /// Get the highest price of all the locations
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An ActionResult with the result</returns>
        [HttpGet]
        [Route("GetMaxPrice")]
        public async Task<ActionResult<int>> GetMaxPrice(CancellationToken cancellationToken)
        {
            try
            {
                var maxPrice = await _locationService.GetMaxPrice(cancellationToken);

                if (maxPrice == null)
                {
                    return NotFound();
                }

                return Ok(maxPrice);
            }
            catch (Exception e)
            {
                return BadRequest("While trying to get all the unavailable dates, something went wrong: " + e.Message);
            }



        }

        /// <summary>
        /// Get all the details of a locations via the LocationDetailDTO, ImageDTO and LandlordDTO
        /// </summary>
        /// <param name="locationId">The id from the location you want the details from</param>
        /// <param name="cancellation">The cancellationtoken</param>
        /// <returns>An ActionResult with the result</returns>
        [HttpGet]
        [Route("GetDetails/{locationId}")]
        public async Task<ActionResult<LocationDetailDTO>> GetDetails(int locationId, CancellationToken cancellation)
        {
            try
            {
                var location = await _locationService.GetDetails(locationId, cancellation);

                if (location == null)
                {
                    return NotFound();
                }


                return Ok(location);
            }
            catch (Exception e)
            {
                return BadRequest("While trying to get all the detals of the location, something went wrong: " + e.Message);
            }


        }

        /// <summary>
        /// Search through te locations and filter through the features of the location
        /// </summary>
        /// <param name="searchDTO">The location features </param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An ActionResult with the result</returns>
        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<LocationDTOv2>>> Search(
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] SearchDTO? searchDTO, CancellationToken cancellationToken)
        {
            try
            {
                var locations = await _locationService.SearchLocations(searchDTO, cancellationToken);

                if (locations == null)
                {
                    return NotFound();
                }

                return Ok(locations);
            }
            catch (Exception e)
            {
                return BadRequest("While trying to get all the filtered locations, something went wrong: " + e.Message);
            }

        }

        /// <summary>
        /// Get all locations
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An ActionResult with the result</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetLocations(CancellationToken cancellationToken)
        {
            try
            {
                var locations = await _locationService.GetDTOLocations(cancellationToken);

                if (locations == null)
                {
                    return NotFound();
                }

                return Ok(locations);
            }
            catch (Exception e)
            {
                return BadRequest("While trying to get all the locations, something went wrong: " + e.Message);
            }
        }

        /// <summary>
        /// Get all locations, with the GetAll route 
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations(CancellationToken cancellationToken)
        {
            try
            {
                var locations = await _locationService.GetAllLocations(cancellationToken);

                if (locations == null)
                {
                    return NotFound();
                }

                return Ok(locations);

            }

            catch (Exception e)
            {
                return BadRequest("While trying to get all the locations, something went wrong: " + e.Message);
            }

        }

        /// <summary>
        /// Get a specific location
        /// </summary>
        /// <param name="id">The id of the location you want to get</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id, CancellationToken cancellationToken)
        {
            try
            {
                var location = await _locationService.GetSpecificLocation(id, cancellationToken);

                if (location == null)
                {
                    return NotFound();
                }

                return Ok(location);
            }
            catch (Exception e)
            {
                return BadRequest("While trying to get a locations, something went wrong: " + e.Message);
            }
        }

    }
}