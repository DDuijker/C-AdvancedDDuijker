namespace AirBnB.Services
{
    using AirBnB.Interfaces;
    using AirBnB.Models;
    using AirBnB.Models.DTO;
    using AutoMapper;
    using System;
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

        public async Task<IEnumerable<LocationDTOv2>> SearchLocations(SearchDTO searchDTO, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetAll(cancellationToken);

            if (searchDTO.Features != null)
            {
                locations = locations.Where(location => (int)location.Features == searchDTO.Features);
            }

            if (searchDTO.MinPrice != null)
            {
                locations = locations.Where(location => location.PricePerDay >= searchDTO.MinPrice);
            }

            if (searchDTO.MaxPrice != null)
            {
                locations = locations.Where(location => location.PricePerDay <= searchDTO.MaxPrice);
            }

            if (searchDTO.Type != null)
            {
                locations = locations.Where(location => (int)location.LocationType == searchDTO.Type);
            }

            if (searchDTO.Rooms != null)
            {
                locations = locations.Where(location => location.Rooms >= searchDTO.Rooms);
            }

            return locations.Select(location => _mapper.Map<LocationDTOv2>(location));

        }

        public async Task<PriceDTO> GetMaxPrice(CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetAll(cancellationToken);

            //Filter through the locations for the largest price
            var price = locations.Max(l => l.PricePerDay);

            //I used Math.Floor to round down the price to the nearest integerS
            var maxPrice = (int)Math.Floor(price);

            var response = new PriceDTO { Price = (int)price };

            return response;
        }

        public async Task<LocationDetailDTO> GetDetails(int id, CancellationToken cancellation)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id), "Location id must be a positive integer");
                }

                if (id == null)
                {
                    throw new ArgumentException($"Location with ID {id} does not exist.", nameof(id));
                }

                var location = await _locationRepository.GetById(id, cancellation);

                var mappedLocation = _mapper.Map<Location, LocationDetailDTO>(location);

                return mappedLocation;
            }
            catch (Exception e)
            {
                throw new Exception("While trying to get the details of the location, something went wrong", e);
            }

        }



        public async Task<UnAvailableDatesDTO> GetUnAvailableDates(int locationId, CancellationToken cancellationToken)
        {

            var location = await _locationRepository.GetById(locationId, cancellationToken);

            var reservations = location.Reservations;

            //I used a linq query to get all the dates between the start and end date of the reservation
            var unavailableDates = reservations.SelectMany(r =>
                 Enumerable.Range(0, (r.EndDate - r.StartDate).Days + 1)
                     .Select(i => r.StartDate.AddDays(i))).ToList();


            // Een automapper was hier overbodig omdat het om 1 veld ging, dus ik heb hier niet overheen gemapped
            return new UnAvailableDatesDTO { UnAvailableDates = unavailableDates };
        }
    }
}