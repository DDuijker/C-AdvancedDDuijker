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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Define the relations between the models

        // Location >-- Landlord
        modelBuilder.Entity<Location>()
         .HasOne(l => l.Landlord)
         .WithMany(l => l.Locations)
         //If you delete a location, the landlord will not be deleted
         .OnDelete(DeleteBehavior.NoAction);

        //Landlord --< Locations
        modelBuilder.Entity<Landlord>()
            .HasMany(l => l.Locations)
            .WithOne(l => l.Landlord)
            .HasForeignKey(l => l.LandlordId)
            //if you delete a landlord, the locations will be deleted
            .OnDelete(DeleteBehavior.Cascade);

        // Landlord --- Avatar
        modelBuilder.Entity<Landlord>()
            .HasOne(l => l.Avatar) //a landlord has only one optional avatar image
            .WithOne() //avatar or image has no landlord id
            .HasForeignKey<Landlord>(l => l.AvatarId) //the avatar id is the foreign key in the landlord 
            .OnDelete(DeleteBehavior.SetNull); //if an avatar image gets deleted, set avatarid to null

        // Customer --< Reservation
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Reservations)
            .WithOne()
            .HasForeignKey(r => r.CustomerId);

        // Reservation >--- Location
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Location)
            .WithMany(l => l.Reservations)
            .HasForeignKey(r => r.LocationId);



        modelBuilder.Entity<Image>().HasData(
           new Image
           {
               Id = 1,
               Url = "https://upload.wikimedia.org/wikipedia/commons/3/3d/Random_House.jpg",
               IsCover = true
           },
           new Image
           {
               Id = 2,
               Url = "https://carlislehomes.com.au/assets/Uploads/a7e501203f/Contemporary-Allure.jpg",
               IsCover = false
           },
           new Image
           {
               Id = 3,
               Url = "https://cdnstorage.sendbig.com/unreal/female.webp",
               IsCover = false
           }
         );

        //modelBuilder.Entity<Location>().HasData
        //    (
        //    new
        //    {
        //        LocationId = 1,
        //        Title = "The Cozy House",
        //        SubTitle = "A cozy house in the middle of the city",
        //        Description = "This is a cozy house in the middle of the city. It has a nice garden and a big kitchen. It is close to the city center and the train station. It is a perfect place for a family or a group of friends.",
        //        LandlordId = 1,
        //        Features = Features.Breakfast | Features.Bath | Features.PetsAllowed | Features.Smoking | Features.TV | Features.Wifi,
        //        LocationType = LocationType.House,
        //        NumberOfGuests = 4,
        //        PricePerDay = 100F,
        //        Rooms = 2,

        //    }
        //    );
        //modelBuilder.Entity<Landlord>().HasData
        //    (
        //    new
        //    {
        //        LandlordId = 1,
        //        FirstName = "John",
        //        LastName = "Doe",
        //        Email = "johnDoe@gmail.com",
        //        Age = 30,
        //        Phone = "123456789",
        //        AvatarId = 3

        //    }
        //    );
    }
}


