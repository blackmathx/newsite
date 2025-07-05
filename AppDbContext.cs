// AppDbContext.cs

using newsite.Models;
using Microsoft.EntityFrameworkCore;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employee"); // lowercase table name

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName).HasColumnName("firstname");
            entity.Property(e => e.LastName).HasColumnName("lastname");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.Description).HasColumnName("description");
        });
    }
}
