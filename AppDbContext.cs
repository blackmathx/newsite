// AppDbContext.cs

using newsite.Models;
using Microsoft.EntityFrameworkCore;



public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
		
	}

    public DbSet<Employee> Employees { get; set; }


}
