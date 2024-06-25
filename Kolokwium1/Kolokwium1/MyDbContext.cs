using Microsoft.EntityFrameworkCore;
using Kolokwium1.Models;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<CarRental> CarRentals { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Color> Colors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().ToTable("Car");
        modelBuilder.Entity<Client>().ToTable("Client");
        modelBuilder.Entity<CarRental>().ToTable("CarRental");
        modelBuilder.Entity<Model>().ToTable("Model");
        modelBuilder.Entity<Color>().ToTable("Color");
    }
}