
using CustomerManagementApp.Client;

Console.WriteLine("Execution Started");

var client = new ClientApp();
await client.RunSimulation(5);

Console.WriteLine("Execution Completed");
Console.ReadLine();