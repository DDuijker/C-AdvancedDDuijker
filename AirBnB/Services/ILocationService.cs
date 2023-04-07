using AirBnB.Models;
using AirBnB.Models.DTO;
namespace AirBnB.Services
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationDTO>> GetDTOLocations();

        public Task<IEnumerable<LocationDTOv2>> GetDTOv2Locations();
        public Task<IEnumerable<Location>> GetAllLocations();
        public Task<Location> GetSpecificLocation(int locationId);


    }
}
