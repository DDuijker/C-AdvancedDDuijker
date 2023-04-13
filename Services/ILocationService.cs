using AirBnB.Models;
using AirBnB.Models.DTO;
namespace AirBnB.Services
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationDTO>> GetDTOLocations(CancellationToken cancellationToken);
        public Task<LocationDTO> GetDTOLocation(int locationId, CancellationToken cancellationToken);
        public Task<IEnumerable<LocationDTOv2>> GetDTOv2Locations(CancellationToken cancellationToken);
        public Task<LocationDTOv2> GetDTOv2Location(int locationId, CancellationToken cancellationToken);
        public Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken);
        public Task<Location> GetSpecificLocation(int locationId, CancellationToken cancellationToken);

        public Task<PriceDTO> GetMaxPrice(CancellationToken cancellationToken);

        public Task<LocationDetailDTO> GetDetails(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<LocationDTOv2>> SearchLocations(SearchDTO searchDTO, CancellationToken cancellationToken);

        public Task<UnAvailableDatesDTO> GetUnAvailableDates(int locationId, CancellationToken cancellationToken);

    }
}
