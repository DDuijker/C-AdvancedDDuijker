using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        /// Get all locations
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An ActionResult with the result</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetLocations(CancellationToken cancellationToken)
        {

            var locations = await _locationService.GetDTOLocations(cancellationToken);

            if (locations == null)
            {
                return NotFound();
            }

            return Ok(locations);
        }

        /// <summary>
        /// Get all locations, with the GetAll route 
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations(CancellationToken cancellationToken)
        {
            var locations = await _locationService.GetAllLocations(cancellationToken);

            if (locations == null)
            {
                return NotFound();
            }

            return Ok(locations);

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
            var location = await _locationService.GetSpecificLocation(id, cancellationToken);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

    }
}