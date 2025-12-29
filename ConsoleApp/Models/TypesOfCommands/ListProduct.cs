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
		Console.WriteLine("> Fetching all products from the DataBase...\n");
		List<Product> products = context.Products.OrderBy(x => x.Id).ToList();
		
		Console.WriteLine("All registered products in the DataBase:");
		foreach (Product product in products)
		{
			Console.WriteLine($"{product.Id} - Name: {product.Name} | Description: '{product.Description}'");
		}
	}
}