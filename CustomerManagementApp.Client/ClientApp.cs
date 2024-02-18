using CustomerManagementApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementApp.Client
{
	public class ClientApp
	{
		private readonly HttpClient _httpClient;

		public ClientApp()
		{
			var handler = new HttpClientHandler
			{
				ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
			};

			_httpClient = new HttpClient(handler);
			_httpClient.BaseAddress = new Uri("https://localhost:7217/api/Customer/");

		}

		public async Task RunSimulation(int numberOfRequests)
		{
			// Generate a list of  multiple post requests to be sent
			var requestsPost = GeneratePostRequests(numberOfRequests);

			// Send multiple requests in parallel
			await Task.WhenAll(requestsPost);


			// Generate a list of multiple get requests to be sent 
			var requestsGet = GenerateGetRequests(numberOfRequests);

			// Send multiple requests for  Get the data
			await Task.WhenAll(requestsGet);

			Console.WriteLine("Execution Inprogress");
		}

		private List<Task> GeneratePostRequests(int noOfRequests)
		{
			var postTasks = new List<Task>();

			for (int i = 0; i < noOfRequests; i++)
			{
				var customers = GenerateCustomers();
				var postTask = SendPostRequest(customers);
				postTasks.Add(postTask);
			}

			return postTasks;
		}
		private List<Task> GenerateGetRequests(int noOfRequests)
		{
			var getTasks = new List<Task>();
			for (int i = 0; i < noOfRequests; i++)
			{
			
				var getTask = SendGetRequest();
				getTasks.Add(getTask);
			}
			return getTasks;
		}

		private List<CustomerDTO> GenerateCustomers()
		{
			var customers = new List<CustomerDTO>();
			var random = new Random();

			// Generate at least 2 different customers
			for (int i = 0; i < 2; i++)
			{
				var customer = new CustomerDTO
				{
					FirstName = GenerateRandomFirstName(),
					LastName = GenerateRandomLastName(),
					Age = random.Next(10, 91)
					
				};

				customers.Add(customer);
			}

			return customers;
		}

		private async Task SendPostRequest(List<CustomerDTO> customers)
		{
			try
			{
				if(customers.Any(t=>t.Age <18))
				{
					foreach (var item in customers.Where(t => t.Age < 18 && t.Age > 90).ToList())
					{
						Console.WriteLine("{Name} age should not be less than 18 years & not be greater than 90 years",item.FirstName +' '+item.LastName);
					}
					
				}
				var updatedList = customers.Where(t => t.Age >= 18 && t.Age <=90).ToList();
				if (updatedList.Count > 0)
				{
					var response = await _httpClient.PostAsJsonAsync("createCustomers", updatedList);
					response.EnsureSuccessStatusCode();
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		private async Task SendGetRequest()
		{
			try
			{
				var response = await _httpClient.GetAsync("getAllCustomers");
				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private string GenerateRandomFirstName()
		{
			var firstNames = new List<string> { "Leia", "Sadie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos" };
			var random = new Random();
			return firstNames[random.Next(0, firstNames.Count)];
		}

		private string GenerateRandomLastName()
		{
			var lastNames = new List<string> { "Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane" };
			var random = new Random();
			return lastNames[random.Next(0, lastNames.Count)];
		}
	}
}
