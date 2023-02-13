using Microsoft.EntityFrameworkCore;

namespace Crm;

public class CrmContext : DbContext {

    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public CrmContext()
    {
        Database.EnsureCreated();
        System.Console.WriteLine("Database created");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Database=crmdatabase;User=root;Password=");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(c => c.Client)
            .WithMany(o => o.OrderList);
    }
}