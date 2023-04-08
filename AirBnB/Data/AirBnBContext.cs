using AirBnB.Models;
using Microsoft.EntityFrameworkCore;

public class AirBnBContext : DbContext
{

    public AirBnBContext(DbContextOptions<AirBnBContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AirbnbDB;Integrated Security=SSPI;");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Landlord> Landlords { get; set; } = default!;



    public DbSet<Reservation> Reservations { get; set; }



    public DbSet<Location> Locations { get; set; }



    public DbSet<Customer> Customers { get; set; }

    public DbSet<Image> Images { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Landlord>().HasMany(l => l.Locations).WithOne(l => l.Landlord).HasForeignKey(l => l.LandlordId);
        //modelBuilder.Entity<Image>().HasOne(i => i.Landlord).WithOne(l => l.Avatar).HasForeignKey<Landlord>(i => i.AvatarId);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>().HasData(
        new { FirstName = "Djoeke", LastName = "Duijker", Email = "djoekeduijker@live.nl", Age = 20, Phone = "062003882", Id = 1 },
        new { FirstName = "Theoharis", LastName = "Sgouridis", Email = "theoharissgouridis@gmail,com", Age = 22, Phone = "12345678", Id = 2 }
        );




        modelBuilder.Entity<Landlord>().HasData(
        new { FirstName = "Kees", LastName = "van der Spek", Email = "keesvdspek@gmail.com", Age = 55, Id = 1, Phone = "12345678", AvatarId = 1 },
        new { FirstName = "Geert-Jan", LastName = "Barends", Email = "geertjan@gmail.com", Id = 2, Age = 61, Phone = "12345678", AvatarId = 2 }

        );





        modelBuilder.Entity<Location>().HasData(
        new { Id = 1, Rooms = 3, Description = "Huis in het centrum", Features = Features.Breakfast, SubTitle = "Huis word al jaren goed bevonden door 100+ klanten", NumberOfGuests = 3, Title = "Almere Apartement", LocationType = LocationType.Appartment, PricePerDay = 50.99F, LandlordId = 1, ImageId = 3 },
        new { Id = 2, Rooms = 4, Description = "Boerderij huisje, lekker afgelegen en dieren zijn toegestaan", Features = Features.PetsAllowed, SubTitle = "Prijzig, maar een echte landelijke ervaring.", NumberOfGuests = 10, Title = "Woonboerderij", LocationType = LocationType.House, PricePerDay = 500.99F, LandlordId = 2, ImageId = 4 }
        );




        modelBuilder.Entity<Image>().HasData(
        new { Id = 1, IsCover = false, Url = "https://dq1eylutsoz4u.cloudfront.net/2019/12/20060024/adult-man-baby-boomer-clean-cut_t20_b8wV6V-800x600-50-year-old-man.jpg" },
        new { Id = 2, IsCover = false, Url = "https://as1.ftcdn.net/v2/jpg/04/70/50/70/1000_F_470507000_FxGToXZnkwPgMYAc5KdX9SvtlYLjPhKf.jpg" },
        new { Id = 3, IsCover = true, Url = "https://www.integervastgoed.nl/img/oasis-city-almere-1.png", LocationId = 1 },
        new { Id = 4, IsCover = true, Url = "https://assets-global.website-files.com/604668223c6f81ba87398bd4/60a2585a0441561aaca31be4_vooraanzicht%20woning.jpg", LocationId = 2 }


        );







        modelBuilder.Entity<Reservation>().HasData(
        new { Id = 1, StartDate = new DateTime(2022, 6, 1), EndDate = new DateTime(2022, 7, 1), CustomerId = 1, LocationId = 1, Discount = 0F },
        new { Id = 2, StartDate = new DateTime(2022, 6, 7), EndDate = new DateTime(2022, 7, 7), CustomerId = 2, LocationId = 2, Discount = 0F }



        );








    }

}


