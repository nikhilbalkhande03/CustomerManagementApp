using CustomerManagementApp.Application.CustomerService;
using CustomerManagementApp.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerManagementApp.API.Controllers
{
	
	public class CustomerController : BaseAPIController
	{
		private readonly ICustomerService _customerService;
		private static object lockObject = new object();
		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpPost("createCustomers")]
		public async Task<IActionResult> AddCustomers([FromBody] List<CustomerDTO> customerDtos)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				lock (lockObject)
				{
					_customerService.CreateCustomers(customerDtos);

					return Ok("All Customers added Successfully.");
				}
			}
			catch (Exception ex) 
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred while adding customers: {ex.Message}");
			}
		}

		[HttpGet("getAllCustomers")]
		public async Task<IActionResult> GetAllCustomers()
		{
			try
			{
				List<CustomerDTO>? customers = await _customerService.GetAllCustomers();

				return Ok(customers);
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred while retrieving customers: {ex.Message}");
			}
		}

	}
}
