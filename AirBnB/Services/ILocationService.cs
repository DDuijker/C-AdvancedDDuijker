using AirBnB.Models;

namespace AirBnB.Services
{
    public interface ILocationService
    {
        public IEnumerable<Location> GetAllLocations();
        public Location GetSpecificLocation(int locationId);


    }
}
