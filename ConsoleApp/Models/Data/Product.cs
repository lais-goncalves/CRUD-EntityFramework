using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models;

public class Product
{
	[Column("Id")]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public Product(int id, string name, string description)
	{
		Id = id;
		Name = name;
		Description = description;
	}
	
	public Product(string name, string description)
	{
		Name = name;
		Description = description;
	}
}