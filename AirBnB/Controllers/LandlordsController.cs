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

        // GET: api/Landlords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Landlord>>> GetLandlords(CancellationToken cancellationToken)
        {
            var result = await _landlordRepository.GetAll(cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Landlords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Landlord>> GetLandlord(int id, CancellationToken cancellationToken)
        {
            var landlord = await _landlordRepository.GetById(id, cancellationToken);

            if (landlord == null)
            {
                return NotFound();
            }

            return landlord;
        }


        //// PUT: api/Landlords/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLandlord(int id, Landlord landlord, CancellationToken cancellationToken)
        //{
        //    if (id != landlord.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _landlordRepository.Entry(landlord).State = EntityState.Modified;

        //    try
        //    {
        //        await _landlordRepository.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LandlordExists(id, cancellationToken))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Landlords
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Landlord>> PostLandlord(Landlord landlord)
        //{
        //    _landlordRepository.Landlords.Add(landlord);
        //    await _landlordRepository.SaveChangesAsync();

        //    return CreatedAtAction("GetLandlord", new { id = landlord.Id }, landlord);
        //}

        //// DELETE: api/Landlords/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLandlord(int id)
        //{
        //    var landlord = await _landlordRepository.Landlords.FindAsync(id);
        //    if (landlord == null)
        //    {
        //        return NotFound();
        //    }

        //    _landlordRepository.Landlords.Remove(landlord);
        //    await _landlordRepository.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool LandlordExists(int id, CancellationToken cancellationToken)
        //{
        //    return _landlordRepository.GetById(id, cancellationToken) != null;
        //}
    }
}
