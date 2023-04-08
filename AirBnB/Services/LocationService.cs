namespace AirBnB.Services
{
    using AirBnB.Interfaces;
    using AirBnB.Models;
    using AirBnB.Models.DTO;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationDTO>> GetDTOLocations(CancellationToken cancellationToken)
        {

            var locations = (await _locationRepository.GetAll(cancellationToken));
            return locations.Select(location => _mapper.Map<Location, LocationDTO>(location));
        }

        public async Task<IEnumerable<LocationDTOv2>> GetDTOv2Locations(CancellationToken cancellationToken)
        {
            return (await _locationRepository.GetAll(cancellationToken)).Select(location => _mapper.Map<Location, LocationDTOv2>(location));
        }

        public async Task<IEnumerable<Location>> GetAllLocations(CancellationToken cancellationToken)
        {

            return await _locationRepository.GetAll(cancellationToken);
        }

        public async Task<Location> GetSpecificLocation(int locationId, CancellationToken cancellationToken)
        {
            return await _locationRepository.GetById(locationId, cancellationToken);
        }

        public async Task<LocationDTO> GetDTOLocation(int locationId, CancellationToken cancellationToken)
        {
            var location = (await _locationRepository.GetById(locationId, cancellationToken));
            return _mapper.Map<Location, LocationDTO>(location);
        }

        public async Task<LocationDTOv2> GetDTOv2Location(int locationId, CancellationToken cancellationToken)
        {
            var location = (await _locationRepository.GetById(locationId, cancellationToken));
            return _mapper.Map<Location, LocationDTOv2>(location);
        }
    }
}
