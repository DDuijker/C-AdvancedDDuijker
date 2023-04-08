using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Controllers.V2
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/[controller]?api-version={version:apiVersion}")]
    [ApiVersion("2.0")]

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
        /// Get all loations via DTOv2, with added price (per day) and type
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTOv2>>> GetLocations(CancellationToken cancellationToken)
        {
            var locations = await _locationService.GetDTOv2Locations(cancellationToken);

            if (locations == null)
            {
                return NotFound();
            }

            return Ok(locations);
        }

        /// <summary>
        /// Get a specific location, mapped to the DTO
        /// </summary>
        /// <param name="id">the id of the lcoation you want to get</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTOv2>> GetLocation(int id, CancellationToken cancellationToken)
        {
            var location = await _locationService.GetDTOv2Location(id, cancellationToken);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);

        }
    }
}
