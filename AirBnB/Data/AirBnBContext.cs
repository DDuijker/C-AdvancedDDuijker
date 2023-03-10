using AirBnB.Models;
using Microsoft.EntityFrameworkCore;

public class AirBnBContext : DbContext
{
    public DbSet<Landlord> Landlords { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Image> Images { get; set; }

    //public DbSet<Review> Reviews { get; set; }

    public AirBnBContext(DbContextOptions<AirBnBContext> options) : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Location>()
    //     .HasOne(l => l.Landlord)
    //     .WithMany()
    //     .OnDelete(DeleteBehavior.NoAction)
    //     ;
    //}
}


