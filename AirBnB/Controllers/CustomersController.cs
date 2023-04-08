using AirBnB.Interfaces;
using AirBnB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult with an IEnumerable list of the customers</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll(cancellationToken);

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        /// <summary>
        /// Get a specific customer
        /// </summary>
        /// <param name="id">The id of the specific customer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The customer with the corresponding id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(id, cancellationToken);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="id">The id of the customer you want to update</param>
        /// <param name="customer">The data of the user you want to update</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Nothing</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer, CancellationToken cancellationToken)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _customerRepository.Add(customer);

            try
            {
                await _customerRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id, cancellationToken))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customer">The customer data</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {


            _customerRepository.Add(customer);
            await _customerRepository.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="id">The ID of the customer to delete</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(id, cancellationToken);
            if (customer == null)
            {
                return NotFound();
            }

            _customerRepository.Delete(id);
            await _customerRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Check if customer exists
        /// </summary>
        /// <param name="id">The ID of the customer to check</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A true or false</returns>
        private bool CustomerExists(int id, CancellationToken cancellationToken)
        {
            return _customerRepository.GetById(id, cancellationToken) != null;
        }
    }
}
