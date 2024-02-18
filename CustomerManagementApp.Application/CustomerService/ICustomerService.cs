using CustomerManagementApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementApp.Application.CustomerService
{
	public interface ICustomerService
	{
		Task<List<CustomerDTO>> GetAllCustomers();

		Task CreateCustomers(List<CustomerDTO> customers);
	}
}
