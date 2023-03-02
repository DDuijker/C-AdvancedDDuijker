using AirBnB.Models;
using Microsoft.EntityFrameworkCore;


public class AirbnbContext : DbContext
{
    public DbSet<Landlord> Landlords { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirbnbDB;Integrated Security=True;");
    }
}
