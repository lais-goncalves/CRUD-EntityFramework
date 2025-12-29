using ConsoleApp.Data;

namespace ConsoleApp.Models.TypesOfCommands;

public class Exit : Command
{
	public override string Name => "Exit";
	public static string StaticCaller => "exit";
	public override string Caller => StaticCaller;
	public override string Description => "Stops and exits the program.";
	
	public Exit(ConsoleAppDbContext context) : base(context) { }
	
	protected override void RunContent()
	{
		Console.WriteLine("> Exiting program...");
		Environment.Exit(0);
	}
}