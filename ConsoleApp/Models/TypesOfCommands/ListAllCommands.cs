using ConsoleApp.Data;

namespace ConsoleApp.Models.TypesOfCommands;

public class ListAllCommands : Command
{
	public override string Name => "List all commands";
	public override string Caller => "list-commands";
	public override string Description => "Lists all commands available.";
	private List<Command> commands { get; set; }
	
	public ListAllCommands(ConsoleAppDbContext context, List<Command> listOfCommands) : base(context)
	{
		commands = listOfCommands;
	}

	public void SetCommands(List<Command> commands)
	{
		this.commands = commands.OrderBy(c => c.Name).ToList();
	}
	
	protected override void RunContent()
	{
		Console.WriteLine("AVAILABLE COMMANDS:\n");

		if (commands.Count == 0)
		{
			Console.WriteLine("No commands available.");
			return;
		}
		
		foreach (Command command in commands)
		{
			Console.WriteLine($"{command.Caller}: {command.Description}");
		}
	}
}