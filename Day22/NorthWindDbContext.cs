using Microsoft.EntityFrameworkCore;
using Day22.Model;
namespace Day22;

public class NorthWindDbContext : DbContext
{	
	public virtual DbSet<Category> Categories { get; set; }
	public virtual DbSet<Product> Products { get; set; }
	
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Filename=./Northwind.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Category
		modelBuilder.Entity<Category>(cat => 
		{
			cat.HasKey(e => e.CategoryId);
			cat.Property(e => e.CategoryName).IsRequired().HasMaxLength(40);
			cat.Property(e => e.Description).HasColumnType("NTEXT");
			cat.HasMany(cat => cat.Products).WithOne(p => p.Category);
		});
		
		// Product
		modelBuilder.Entity<Product>(pro =>
		{
			pro.Property(p => p.ProductName).IsRequired().HasMaxLength(40);
			pro.Property(p => p.Cost).HasColumnType("money").HasColumnName("UnitPrice");
			// pro.HasOne(p => p.Category).WithMany(cat => cat.Products);
		});
		
		// Order Detail
		modelBuilder.Entity<OrderDetail>(order =>
		{
			order.HasKey(o => new { o.OrderId, o.ProductId });
		});
	}


}
