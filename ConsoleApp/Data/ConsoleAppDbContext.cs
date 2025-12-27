using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public class ConsoleAppDbContext : DbContext
{
	public DbSet<Person> People { get; set; }
	public DbSet<Product> Products { get; set; }

	private string DbPath => DefinePath();

	public ConsoleAppDbContext() { }
	
	public string DefinePath()
	{
		var folder = AppContext.BaseDirectory;
		var combinedPath = Path.Combine(folder, "..", "..", "..", "Data", "db.sqlite3");
		return Path.GetFullPath(combinedPath);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
		optionsBuilder.UseSqlite($"Data Source={DbPath}");
}