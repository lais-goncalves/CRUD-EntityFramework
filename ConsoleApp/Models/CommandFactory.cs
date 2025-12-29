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
				Console.WriteLine($"The command '{commandCaller}' was not found.\n");
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
			new RegisterProduct(context),
			new ListProducts(context),
			listCommands
		];
		
		listCommands.SetCommands(_commands);
		return _commands;
	}
}