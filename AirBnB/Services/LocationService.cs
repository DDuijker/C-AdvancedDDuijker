namespace AirBnB.Services
{
    using AirBnB.Interfaces;
    using AirBnB.Models;
    using System.Collections.Generic;

    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        IEnumerable<Location> ILocationService.GetAllLocations()
        {
            return _locationRepository.GetAll();
        }

        Location ILocationService.GetSpecificLocation(int locationId)
        {
            return _locationRepository.GetById(locationId);
        }
    }
}
