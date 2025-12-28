using ConsoleApp.Data;

namespace ConsoleApp.Models.TypesOfCommands;

public class ListPeople : Command
{
	public override string Name => "List registered people";
	public override string Caller => "list-people";
	public override string Description => "Lists all registered people in the DataBase.";
	
	public ListPeople(ConsoleAppDbContext context) : base(context) { }
	
	protected override void RunContent()
	{
		Console.WriteLine("Fetching all people from the database...\n");
		
		List<Person> people = context.People.ToList();

		foreach (Person person in people)
		{
			Console.WriteLine($"Person #{person.Id}'s name: {person.Name} | Age: {person.Age}");
		}
	}
}