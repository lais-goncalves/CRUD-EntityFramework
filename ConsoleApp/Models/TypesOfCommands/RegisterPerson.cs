using ConsoleApp.Data;

namespace ConsoleApp.Models.TypesOfCommands;

public class RegisterPerson(ConsoleAppDbContext context) : Command(context)
{
	public override string Name => "Register Person";
	public override string Caller => "register-person";
	public override string Description => "Registers someone into the DataBase.";

	protected override void RunContent()
	{
		Console.Write("Enter the name of the person: ");
		string? name = Console.ReadLine();
			
		if (name == null)
		{
			throw new Exception("Name cannot be null.");
		}
			
		Console.Write("Enter their age: ");
		string? age = Console.ReadLine();
		_ = int.TryParse(age, out int ageInt);
			
		Console.WriteLine($"\nRegistering person '{name}'...");
			
		var person = new Person(name, ageInt);
		context.Add(person);
		context.SaveChanges();
			
		Console.WriteLine($"Person '{name}' was successfully registered.");
	}
}