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

        // GET: api/Locations
        [HttpGet]

        public async Task<IEnumerable<LocationDTO>> GetLocations(CancellationToken cancellationToken)
        {

            return await _locationService.GetDTOLocations(cancellationToken);
        }

        // GET: api/Locations/GetAll
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken)
        {
            return await _locationService.GetAllLocations(cancellationToken);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<Location> GetLocation(int id, CancellationToken cancellationToken)
        {
            var location = await _locationService.GetSpecificLocation(id, cancellationToken);

            if (location == null)
            {
                return null;
            }

            return location;
        }

    }
}