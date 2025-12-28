using ConsoleApp.Data;

namespace ConsoleApp.Models;

public abstract class Command
{
	public abstract string Name { get; }
	public abstract string Caller { get; }
	public abstract string Description { get; }
	
	protected ConsoleAppDbContext context { get; }
	
	public Command(ConsoleAppDbContext context)
	{
		this.context = context;
	}

	protected abstract void RunContent();

	public void Run()
	{
		RunContent();
		Console.WriteLine("");
	}
}