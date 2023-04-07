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

        public async Task<IEnumerable<LocationDTO>> GetDTOLocations()
        {

            return (await _locationRepository.GetAll()).Select(location => _mapper.Map<Location, LocationDTO>(location));
        }

        public async Task<IEnumerable<LocationDTOv2>> GetDTOv2Locations()
        {
            return (await _locationRepository.GetAll()).Select(location => _mapper.Map<Location, LocationDTOv2>(location));
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {

            return await _locationRepository.GetAll();
        }

        Location ILocationService.GetSpecificLocation(int locationId)
        {
            return _locationRepository.GetById(locationId);
        }
    }
}
