using CustomerManagementApp.Domain.Customer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerManagementApp.Infrastructure.CustomerRepository
{
	public class CustomerRepository: ICustomerRepository
	{
		private readonly string _filePath = "customerList.json";
		
		public CustomerRepository()
		{
		
		}
		public async Task CreateCustomers(List<Customer> customer)
		{
			List<Customer> _customers = ReadFromJsonFileAsync();			 
			try
			{
				foreach (var item in customer)
				{
					if (customer.Count() > 0)
					{
						item.Id = _customers.OrderByDescending(t=>t.Id).Select(t=>t.Id).FirstOrDefault()+1;
						await InsertCustomerSorted(item,_customers);
					}

				}
				 SaveToJsonFileAsync(_customers);
			}
			catch (Exception ex)
			{

				throw;
			}						
		}

		public async Task<List<Customer>> GetAllCustomers()
		{
			List<Customer> _customers = ReadFromJsonFileAsync();
			var checkCondition = new[]
			{
				_customers == null,
				_customers?.Count !=0
			};

			if (checkCondition.Any(x => x))
			{
				_customers = new List<Customer>();
			}
			else
			{
				_customers = ReadFromJsonFileAsync();
			}
			return await Task.FromResult(_customers);
		}


		private void SaveToJsonFileAsync(List<Customer> customers)
		{		
			using (var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
			{
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				System.Text.Json.JsonSerializer.Serialize(fileStream, customers, options);
				fileStream.Close();
			}
		
		}
		private List<Customer> ReadFromJsonFileAsync()
		{
			List<Customer> _customers = new List<Customer>();
			// Read the JSON data from the file asynchronously
			using (var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
			{
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

				try
				{
					if (fileStream.Length != 0)
					{
						_customers =   System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(fileStream, options);
					}
					
				}
				catch (Exception ex)
				{
					_customers = new List<Customer>();
				}
				fileStream.Close();
			}
			return _customers;
		}

		private async Task<List<Customer>> InsertCustomerSorted(Customer customer,List<Customer> _customers)
		{
			int index = 0;
			
			while (index < _customers.Count &&
				   String.Compare(customer.LastName, _customers[index].LastName, StringComparison.Ordinal) > 0)
			{
				index++;
			}

			while (index < _customers.Count &&
				   String.Compare(customer.LastName, _customers[index].LastName, StringComparison.Ordinal) == 0 &&
				   String.Compare(customer.FirstName, _customers[index].FirstName, StringComparison.Ordinal) > 0)
			{
				index++;
			}
			
			_customers.Insert(index, customer);
			return _customers;
		}
	}
}
