using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class DataContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    
    public DataContext(DbContextOptions<DataContext> opts) : base(opts)
    {
        
    }
}