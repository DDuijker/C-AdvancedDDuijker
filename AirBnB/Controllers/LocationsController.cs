using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        // GET: api/Locations
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Location> GetAllLocations()
        {
            return _locationService.GetAllLocations();
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

        //// PUT: api/Locations/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLocation(int id, Location location)
        //{
        //    if (id != location.LocationId)
        //    {
        //        return BadRequest();
        //    }

        //    _locationService.Entry(location).State = EntityState.Modified;

        //    try
        //    {
        //        await _locationService.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LocationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Locations
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Location>> PostLocation(Location location)
        //{
        //    _locationService.Locations.Add(location);
        //    await _locationService.SaveChangesAsync();

        //    return CreatedAtAction("GetLocation", new { id = location.LocationId }, location);
        //}

        //// DELETE: api/Locations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLocation(int id)
        //{
        //    var location = await _locationService.Locations.FindAsync(id);
        //    if (location == null)
        //    {
        //        return NotFound();
        //    }

        //    _locationService.Locations.Remove(location);
        //    await _locationService.SaveChangesAsync();

        //    return NoContent();
        //}

        //    private bool LocationExists(int id)
        //    {
        //        var location = _locationService.GetSpecificLocation(id);
        //        return location != null;
        //    }
        //}
    }
}