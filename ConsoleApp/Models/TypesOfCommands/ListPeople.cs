using ConsoleApp.Data;

namespace ConsoleApp.Models.TypesOfCommands;

public class ListPeople : Command
{
	public override string Name => "List registered persons";
	public override string Caller => "list-persons";
	public override string Description => "Lists all registered persons in the DataBase.";
	
	public ListPeople(ConsoleAppDbContext context) : base(context) { }
	
	protected override void RunContent()
	{
		Console.WriteLine("> Fetching all persons from the DataBase...\n");
		List<Person> persons = context.People.OrderBy(x => x.Id).ToList();

		Console.WriteLine("All registered persons in the DataBase:");
		foreach (Person person in persons)
		{
			Console.WriteLine($"{person.Id} - Name: {person.Name} | Age: {person.Age}");
		}
	}
}