using AutoMapper;
using CustomerManagementApp.Application.DTO;
using CustomerManagementApp.Domain.Customer;
using CustomerManagementApp.Infrastructure.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementApp.Application.CustomerService
{
	public class CustomerService:ICustomerService
	{

		private readonly ICustomerRepository _customerRepository;
		private readonly IMapper _mapper;
		public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
			_mapper = mapper;
		}
		public async Task CreateCustomers(List<CustomerDTO> customers)
		{
			var customer = _mapper.Map<List<Customer>>(customers);
			
			if (customer.Count() > 0)
			{
				await _customerRepository.CreateCustomers(customer);
			}
		}

		public async Task<List<CustomerDTO>> GetAllCustomers()
		{
			var customers = await _customerRepository.GetAllCustomers();
			var customerDtos = _mapper.Map<List<CustomerDTO>>(customers);
			return customerDtos;
		}
	}
}
