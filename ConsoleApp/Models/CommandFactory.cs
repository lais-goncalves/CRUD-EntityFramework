using ConsoleApp.Data;
using ConsoleApp.Models.TypesOfCommands;

namespace ConsoleApp.Models;

public class CommandFactory
{
	private ConsoleAppDbContext context { get; }
	private List<Command> commands { get; set; }

	public CommandFactory(ConsoleAppDbContext context)
	{
		this.context = context;
		commands = defineCommands();
	}

	public void RunCommand(string commandCaller)
	{
		Command? command = commands.Find(x => x.Caller == commandCaller);

		switch (command)
		{
			case null:
				Console.WriteLine($"Command '{commandCaller}' not found.");
				return;
			default:   command.Run(); break;
		}
	}

	private List<Command> defineCommands()
	{
		ListAllCommands listCommands = new (context, []);
		
		List<Command> _commands =
		[
			new Exit(context),
			new RegisterPerson(context),
			new ListPeople(context),
			listCommands
		];
		
		listCommands.SetCommands(_commands);
		return _commands;
	}

	public void ListPeople()
	{
		Console.WriteLine("'list-people' command chosen...\n");
		
		List<Person> people = context.People.OrderBy(x => x.Id).ToList();
		foreach (Person person in people)
		{
			Console.WriteLine($"Person #{person.Id}: '{person.Name}', is {person.Age} years old.");
		}
	}
	
	public void ListProducts()
	{
		Console.WriteLine("'list-products' command chosen...\n");
		
		List<Product> products = context.Products.OrderBy(x => x.Id).ToList();
		foreach (Product product in products)
		{
			Console.WriteLine($"Product #{product.Id}: '{product.Name}', description: '{product.Description}'");
		}
	}
	
	public void RegisterProduct()
	{
		try
		{
			Console.WriteLine("'register-product' command chosen...\n");
			
			Console.Write("Enter the product's name: ");
			string? name = Console.ReadLine();
			
			if (name == null)
			{
				throw new Exception("Name cannot be null.");
			}
			
			Console.Write("Enter the product's description: ");
			string description = Console.ReadLine() ?? "";
			
			Console.WriteLine($"\nRegistering product '{name}'...");
			
			var product = new Product(name, description);
			context.Add(product);
			context.SaveChanges();
			
			Console.WriteLine($"Product '{name}' was successfully registered.");
		}

		catch (Exception)
		{
			throw new Exception("Something went wrong. Try again.");
		}
	}
}