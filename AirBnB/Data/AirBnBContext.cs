using AirBnB.Models;
using Microsoft.EntityFrameworkCore;


public class AirBnBContext : DbContext
{
    public DbSet<Landlord> Landlords { get; set; }
    public DbSet<Location> Locations { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirbnbDB;Integrated Security=True;");
    }
}
