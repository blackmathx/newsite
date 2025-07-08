// AppDbContext.cs

using newsite.Models;
using Microsoft.EntityFrameworkCore;



public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	public DbSet<Employee> Employees { get; set; }
	public DbSet<Post> Posts { get; set; }
	public DbSet<UserComment> UserComments { get; set; }
	public DbSet<Submission> Submissions { get; set; }


}
