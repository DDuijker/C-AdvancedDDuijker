using AirBnB.Interfaces;
using AirBnB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordsController : ControllerBase
    {
        private readonly ILandlordRepository _landlordRepository;

        public LandlordsController(ILandlordRepository repository)
        {
            _landlordRepository = repository;
        }

        /// <summary>
        /// Get all landlords
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Landlord>>> GetLandlords(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _landlordRepository.GetAll(cancellationToken);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("While trying to get all the landlords, something went wrong: " + e.Message);
            }

        }

        /// <summary>
        /// Get a landlord by id
        /// </summary>
        /// <param name="id">The id of the landlord you want to get</param>
        /// <param name="cancellationToken">The cancellationtoken</param>
        /// <returns>The landlord or a notfound error</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Landlord>> GetLandlord(int id, CancellationToken cancellationToken)
        {
            try
            {
                var landlord = await _landlordRepository.GetById(id, cancellationToken);

                if (landlord == null)
                {
                    return NotFound();
                }

                return landlord;
            }
            catch (Exception e)
            {
                return BadRequest("While trying to get all the landlords, something went wrong: " + e.Message);
            }
        }
    }
}
