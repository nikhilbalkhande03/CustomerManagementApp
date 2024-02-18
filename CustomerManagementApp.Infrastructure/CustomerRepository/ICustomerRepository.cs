using CustomerManagementApp.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementApp.Infrastructure.CustomerRepository
{
	public interface ICustomerRepository
	{
		Task<List<Customer>> GetAllCustomers();
		Task CreateCustomers(List<Customer> customer);
	}
}
