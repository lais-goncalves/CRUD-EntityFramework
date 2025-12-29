using ConsoleApp.Data;

namespace ConsoleApp.Models.TypesOfCommands;

public class RegisterProduct(ConsoleAppDbContext context) : Command(context)
{
	public override string Name => "Register product";
	public override string Caller => "register-product";
	public override string Description => "Registers a product into the DataBase.";

	protected override void RunContent()
	{
		Console.Write("Enter the name of the product: ");
		string? name = Console.ReadLine();
			
		if (name == null)
		{
			throw new Exception("Name cannot be null.");
		}
			
		Console.Write("Enter its description: ");
		string? description = Console.ReadLine();
			
		Console.WriteLine($"\nRegistering product '{name}'...");
			
		var product = new Product(name, description ?? "");
		context.Add(product);
		context.SaveChanges();
			
		Console.WriteLine($"Product '{name}' was successfully registered.");
	}
}