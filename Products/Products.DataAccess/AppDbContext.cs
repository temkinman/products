
using Microsoft.EntityFrameworkCore;
using Products.Domain.Models;

namespace Products.DataAccess;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products);

        modelBuilder.Entity<Product>()
            .HasOne(c => c.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(c => c.CategoryId);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
