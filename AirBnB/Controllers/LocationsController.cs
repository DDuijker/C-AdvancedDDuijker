﻿using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AirBnB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]

    public class LocationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetMaxPrice")]
        public async Task<ActionResult<int>> GetMaxPrice(CancellationToken cancellationToken)
        {
            var maxPrice = await _locationService.GetMaxPrice(cancellationToken);

            if (maxPrice == null)
            {
                return NotFound();
            }

            return Ok(maxPrice);
        }

        [HttpGet]
        [Route("GetDetails/{locationId}")]
        public async Task<ActionResult<LocationDetailDTO>> GetDetails(int locationId, CancellationToken cancellation)
        {
            //get the location with the id from the URL

            var location = await _locationService.GetDetails(locationId, cancellation);

            if (location == null)
            {
                return NotFound();
            }


            return Ok(location);
        }

        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<LocationDTOv2>>> Search(
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] SearchDTO? searchDTO, CancellationToken cancellationToken)
        {

            var locations = await _locationService.SearchLocations(searchDTO, cancellationToken);

            if (locations == null)
            {
                return NotFound();
            }


            return Ok(locations);
        }

        /// <summary>
        /// Get all locations
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An ActionResult with the result</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetLocations(CancellationToken cancellationToken)
        {

            var locations = await _locationService.GetDTOLocations(cancellationToken);

            if (locations == null)
            {
                return NotFound();
            }

            return Ok(locations);
        }

        /// <summary>
        /// Get all locations, with the GetAll route 
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations(CancellationToken cancellationToken)
        {
            var locations = await _locationService.GetAllLocations(cancellationToken);

            if (locations == null)
            {
                return NotFound();
            }

            return Ok(locations);

        }

        /// <summary>
        /// Get a specific location
        /// </summary>
        /// <param name="id">The id of the location you want to get</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id, CancellationToken cancellationToken)
        {
            var location = await _locationService.GetSpecificLocation(id, cancellationToken);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

    }
}