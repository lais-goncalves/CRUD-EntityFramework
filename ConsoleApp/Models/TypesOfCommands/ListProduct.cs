using ConsoleApp.Data;

namespace ConsoleApp.Models.TypesOfCommands;

public class ListProducts : Command
{
	public override string Name => "List registered products";
	public override string Caller => "list-products";
	public override string Description => "Lists all registered products in the DataBase.";
	
	public ListProducts(ConsoleAppDbContext context) : base(context) { }
	
	protected override void RunContent()
	{
		Console.WriteLine("Fetching all products from the database...\n");
		
		List<Product> products = context.Products.ToList();

		foreach (Product product in products)
		{
			Console.WriteLine($"Product #{product.Id}'s name: {product.Name} | Description: '{product.Description}'");
		}
	}
}