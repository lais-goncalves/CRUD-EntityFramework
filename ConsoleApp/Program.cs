// See https://aka.ms/new-console-template for more information

using ConsoleApp.Data;
using ConsoleApp.Models;

void program()
{
	ConsoleAppDbContext context = new ConsoleAppDbContext();
	
	bool continueRunning = true;
	CommandFactory cmd = new CommandFactory(context);

	Console.Clear();
	cmd.RunCommand("list-commands");
		
	while (continueRunning)
	{
		Console.WriteLine("--------------------------");
		Console.WriteLine("Enter your next command:\n");
		string? command = Console.ReadLine();
		command = command?.ToLower().Trim();

		Console.Clear();
		cmd.RunCommand(command);
	}
}

program();







// Person person1 = new Person(1, "number 1", 1);
// Person person2 = new Person(2, "number 2", 2);
// Person person3 = new Person(3, "number 3", 3);
//
// Product product1 = new Product(1, "product1", "Product #1.");
// Product product2 = new Product(2, "product2", "Product #2.");
// Product product3 = new Product(3, "product3", "Product #3.");
//
// List<Product> products1 = [product1];
// List<Product> products2 = [product2];
// List<Product> products3 = [product3];
//
// person1.Products = products1;
// person2.Products = products2;
// person3.Products = products3;
//
// context.Add(person1);
// context.Add(person2);
// context.Add(person3);
//
// context.SaveChanges();
//
// Person? foundP1 = context.People.FirstOrDefault(p => p.Id == 1);
//
// Console.WriteLine($"Person1: {foundP1?.Id}, {foundP1?.Name},  {foundP1?.Age}");
