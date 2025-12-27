using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Models;

public class Person
{
	[Column("Id")]
	public int Id { get; set; }
	public string Name { get; set; }
	public int Age { get; set; }

	public List<Product> Products { get; set; }

	public Person(int id, string name, int age)
	{
		Id = id;
		Name = name;
		Age = age;
	}
	
	public Person(string name, int age)
	{
		Name = name;
		Age = age;
	}
}