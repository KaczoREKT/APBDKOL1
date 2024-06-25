using Microsoft.EntityFrameworkCore;
using Kolokwium1.Models;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Car> Car { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<CarRental> CarRental { get; set; }
    public DbSet<Model> Model { get; set; }
    public DbSet<Color> Color { get; set; }
}