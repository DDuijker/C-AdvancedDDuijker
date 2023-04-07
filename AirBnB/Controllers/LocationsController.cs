using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/[controller]?api-version={version:apiVersion}")]
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

        public IEnumerable<LocationDTO> GetLocations()
        {

            return _locationService.GetAllLocations().Select(location => _mapper.Map<Location, LocationDTO>(location));
        }

        // GET: api/Locations/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<LocationDTO> GetAllLocations()
        {
            var locations = _locationService.GetAllLocations();
            return _mapper.Map<IEnumerable<Location>, IEnumerable<LocationDTO>>(locations);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public Location GetLocation(int id)
        {
            var location = _locationService.GetSpecificLocation(id);

            if (location == null)
            {
                return null;
            }

            return location;
        }

    }
}