using AirBnB.Models;
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

        // GET: api/Locations
        [HttpGet]
        public IEnumerable<LocationDTOv2> GetLocations()
        {
            return _locationService.GetAllLocations().Select(location => _mapper.Map<Location, LocationDTOv2>(location));
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public Location GetLocation(int id)
        {
            return _locationService.GetSpecificLocation(id);
        }
    }
}
