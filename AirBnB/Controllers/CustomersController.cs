using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AirBnB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get all customers, via CustomerResponseDTO
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult with an IEnumerable list of the customers</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _customerService.GetAllCustomers(cancellationToken);

                if (customers == null)
                {
                    return NotFound();
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
            try
            {
                var customer = await _customerService.GetCustomerById(id, cancellationToken);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception e)
            {
                return BadRequest("While getting the customer, something went wrong: " + e.Message);
            }
        }

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customer">The customer data</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpPost]
        public async Task<ActionResult<CustomerResponseDTO>> PostCustomer(CustomerRequestDTO customerRequestDTO, CancellationToken cancellationToken)
        {
            try
            {
                var customerData = new Customer
                {
                    Email = customerRequestDTO.Email,
                    FirstName = customerRequestDTO.FirstName,
                    LastName = customerRequestDTO.LastName,
                };

                var customer = await _customerService.CreateCustomer(customerData, cancellationToken);
                await _customerService.SaveChangesAsync();

                return Ok(customer);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest("While trying to add the customer, something went wrong: " + e.Message);
            }

        }


    }
}
