using AirBnB.Models;
using AirBnB.Models.DTO;
namespace AirBnB.Services
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationDTO>> GetDTOLocations(CancellationToken cancellationToken);

        public Task<IEnumerable<LocationDTOv2>> GetDTOv2Locations(CancellationToken cancellationToken);
        public Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken);
        public Task<Location> GetSpecificLocation(int locationId, CancellationToken cancellationToken);


    }
}
