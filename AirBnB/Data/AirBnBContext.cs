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
        new { FirstName = "Theoharis", LastName = "Sgouridis", Email = "theoharissgouridis@gmail.com", Age = 22, Phone = "12345678", Id = 2 }
        );




        modelBuilder.Entity<Landlord>().HasData(
        new { FirstName = "Kees", LastName = "van der Spek", Email = "keesvdspek@gmail.com", Age = 55, Id = 1, Phone = "12345678", AvatarId = 1 },
        new { FirstName = "Geert-Jan", LastName = "Barends", Email = "geertjan@gmail.com", Id = 2, Age = 61, Phone = "12345678", AvatarId = 2 },
        new
        {
            Id = 3,
            FirstName = "Karin",
            LastName = "Janssen",
            Email = "karinjanssen@gmail.com",
            Age = 45,
            Phone = "12345678",
            AvatarId = 17
        }

        );





        modelBuilder.Entity<Location>().HasData(
        new { Id = 1, Rooms = 3, Description = "Huis in het centrum", Features = Features.Breakfast | Features.Bath | Features.Wifi, SubTitle = "Huis word al jaren goed bevonden door 100+ klanten", NumberOfGuests = 3, Title = "Almere Apartement", LocationType = LocationType.Appartment, PricePerDay = 50.99F, LandlordId = 1, ImageId = 3 },
        new { Id = 2, Rooms = 4, Description = "Boerderij huisje, lekker afgelegen en dieren zijn toegestaan", Features = Features.PetsAllowed | Features.Bath | Features.Wifi, SubTitle = "Prijzig, maar een echte landelijke ervaring.", NumberOfGuests = 10, Title = "Woonboerderij", LocationType = LocationType.House, PricePerDay = 500.99F, LandlordId = 2, ImageId = 4 },
        new
        {
            Id = 3,
            Rooms = 1,
            Description = "Kamer voor 2 personen",
            Features = Features.Wifi,
            SubTitle = "Kamer op een rustig gelegen plek dichtbij de stad",
            NumberOfGuests = 2,
            Title = "Kamer in Almere",
            LocationType = LocationType.Room,
            PricePerDay = 20.99F,
            LandlordId = 1,
            ImageId = 5
        },
        new { Id = 4, Rooms = 2, Description = "Gezellig chalet in de bossen", Features = Features.Wifi | Features.PetsAllowed, SubTitle = "Verblijf midden in de natuur", NumberOfGuests = 4, Title = "Chalet in de bossen", LocationType = LocationType.Chalet, PricePerDay = 80.99F, LandlordId = 3, ImageId = 10 },
        new { Id = 5, Rooms = 5, Description = "Ruim opgezet hotel met uitzicht op zee", Features = Features.Breakfast | Features.Breakfast | Features.Wifi, SubTitle = "Geniet van luxe en comfort", NumberOfGuests = 2, Title = "Zeezicht hotel", LocationType = LocationType.Hotel, PricePerDay = 120.50F, LandlordId = 1, ImageId = 11 },
        new { Id = 6, Rooms = 1, Description = "Gezellige studio in het centrum", Features = Features.Wifi, SubTitle = "Perfect voor een stedentrip", NumberOfGuests = 2, Title = "Studio in Amsterdam", LocationType = LocationType.Room, PricePerDay = 60.99F, LandlordId = 3, ImageId = 12 },
        new { Id = 7, Rooms = 3, Description = "Rustig gelegen appartement aan de rand van de stad", Features = Features.Bath | Features.Wifi | Features.TV, SubTitle = "Ontsnap aan de drukte van de stad", NumberOfGuests = 4, Title = "Appartement aan de rand van de stad", LocationType = LocationType.Appartment, PricePerDay = 90.00F, LandlordId = 1, ImageId = 13 },
        new { Id = 8, Rooms = 4, Description = "Moderne villa met zwembad en uitzicht op de bergen", Features = Features.Bath | Features.Wifi | Features.TV, SubTitle = "Luxe villa met veel privacy", NumberOfGuests = 6, Title = "Villa met zwembad en bergzicht", LocationType = LocationType.House, PricePerDay = 350.00F, LandlordId = 2, ImageId = 14 },
        new { Id = 9, Rooms = 2, Description = "Gezellig appartement in historisch pand", Features = Features.Bath | Features.Wifi | Features.TV, SubTitle = "Historische sfeer gecombineerd met modern comfort", NumberOfGuests = 3, Title = "Appartement in historisch pand", LocationType = LocationType.Appartment, PricePerDay = 75.00F, LandlordId = 2, ImageId = 15 },
        new { Id = 10, Rooms = 3, Description = "Comfortabel vakantiehuis met privétuin", Features = Features.Wifi | Features.Bath | Features.PetsAllowed | Features.Wifi, SubTitle = "Ideaal voor gezinnen of groepen vrienden", NumberOfGuests = 8, Title = "Vakantiehuis met privétuin", LocationType = LocationType.House, PricePerDay = 180.00F, LandlordId = 3, ImageId = 16 },
        new { Id = 11, Rooms = 3, Description = "Een leuk uitje voor met zijn twee of een klein gezin", Features = Features.Wifi, Features.Bath, SubTitle = "Leuke cottage", NumberOfGuests = 3, Title = "Een stenen cottage", LocationType = LocationType.Cottage, PricePerDay = 30.00F, LandlordId = 3, ImageId = 25 }

        );




        modelBuilder.Entity<Image>().HasData(
        new { Id = 1, IsCover = false, Url = "https://dq1eylutsoz4u.cloudfront.net/2019/12/20060024/adult-man-baby-boomer-clean-cut_t20_b8wV6V-800x600-50-year-old-man.jpg" },
        new { Id = 2, IsCover = false, Url = "https://as1.ftcdn.net/v2/jpg/04/70/50/70/1000_F_470507000_FxGToXZnkwPgMYAc5KdX9SvtlYLjPhKf.jpg" },
        new { Id = 3, IsCover = true, Url = "https://www.integervastgoed.nl/img/oasis-city-almere-1.png", LocationId = 1 },
        new { Id = 4, IsCover = true, Url = "https://assets-global.website-files.com/604668223c6f81ba87398bd4/60a2585a0441561aaca31be4_vooraanzicht%20woning.jpg", LocationId = 2 },
        new { Id = 5, IsCover = true, Url = "https://www.thespruce.com/thmb/iMt63n8NGCojUETr6-T8oj-5-ns=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/PAinteriors-7-cafe9c2bd6be4823b9345e591e4f367f.jpg", locationId = 3 },
        new { Id = 6, IsCover = true, Url = "https://images.squarespace-cdn.com/content/v1/5b097b4a4cde7ab1c2125706/90f9b45a-0c57-44b0-a566-53e4359a817e/CathieHong_Bookins_2.jpg?format=300w", LocationId = 3 },
        new { Id = 7, IsCover = false, Url = "https://theartofliving.nl/wp-content/uploads/2022/12/A1U-Maatwerk-Rob-Feenstra_12.jpg", LocationId = 1 },
        new { Id = 8, IsCover = false, Url = "https://www.drijvers-oisterwijk.nl/wp-content/uploads/2019/01/3201-Drijvers-Oisterwijk-interieur-restauratie-modern-landelijk-houten-spant-strak-licht-maatwerk-12.jpg", LocationId = 2 },
        new { Id = 9, IsCover = true, Url = "https://images.squarespace-cdn.com/content/v1/5b097b4a4cde7ab1c2125706/90f9b45a-0c57-44b0-a566-53e4359a817e/CathieHong_Bookins_2.jpg?format=750w", LocationId = 3 },
        new { Id = 10, IsCover = true, Url = "https://www.hoiveluwe.nl/custom/page/page_content_img/34780_original.jpg", LocationId = 4 },
        new { Id = 11, IsCover = true, Url = "https://www.specialhotels.nl/foto/foto_800_450/26073.jpg", LocationId = 5 },
        new { Id = 12, IsCover = true, Url = "https://040houserental.nl/wp-content/uploads/2022/01/DSC_0011_5_1.jpg", LocationId = 6 },
        new { Id = 13, IsCover = true, Url = "https://media.indebuurt.nl/breda/2022/07/18140124/Miza-Bergen-op-Zoom.jpg", LocationId = 7 },
        new { Id = 14, IsCover = true, Url = "https://www.ruralcoast.com/galeria/inmuebles/chalet-indep-polop-1734-1.jpg", LocationId = 8 },
        new { Id = 15, IsCover = true, Url = "https://cloud.funda.nl/valentina_media/119/434/724_1080x720.jpg", LocationId = 9 },
        new { Id = 16, IsCover = true, Url = "https://images.oyoroomscdn.com/uploads/hotel_image/100011873/medium/88812_lsr_2020052255142949050.jpg", LocationId = 10 },
        new { Id = 17, IsCover = false, Url = "https://st4.depositphotos.com/3429495/38405/i/600/depositphotos_384057762-stock-photo-cannes-france-may-karin-viard.jpg" },
        new { Id = 18, IsCover = false, Url = "https://dotnlgul4mfwg.cloudfront.net/wp-content/uploads/2018/04/13124619/boshuis_friesche_duin17__inline_staand_groot.jpg", LocationId = 4 },
        new { Id = 19, IsCover = false, Url = "https://interiorjunkie.com/wp-content/uploads/2020/10/hotel-chic-badkamer-2-685x1024.jpg", LocationId = 5 },
        new { Id = 20, IsCover = false, Url = "https://images.homify.com/c_fill,f_auto,q_0,w_740/v1560373677/p/photo/image/3088926/P2_APRES.jpg", LocationId = 6 },
        new { Id = 21, IsCover = false, Url = "https://www.inrichting-huis.com/wp-content/afbeeldingen/interieur-appartement-hotelsfeer.jpg", LocationId = 7 },
        new { Id = 22, IsCover = false, Url = "https://www.ruralcoast.com/galeria/inmuebles/chalet-indep-polop-1734-4.jpg", LocationId = 8 },
        new { Id = 23, IsCover = false, Url = "https://img.vtwonen.nl/8a4eb93b559d0a56f0161a681c9fe9da5b2d52fd/5x-binnenkijken-in-een-monumentaal-pand", LocationId = 9 },
        new { Id = 24, IsCover = false, Url = "https://images.oyoroomscdn.com/uploads/hotel_image/100011873/medium/88812_lsr_202002084173854678.jpg", LocationId = 10 },
        new { Id = 25, IsCover = true, Url = "https://www.standout-cabin-designs.com/images/small-stone-cottages1a.jpg", LocationId = 11 },
        new { Id = 26, IsCover = false, Url = "https://usenaturalstone.org/wp-content/uploads/2016/03/Megy-Article-1.jpg", LocationId = 11 }

        );







        modelBuilder.Entity<Reservation>().HasData(
        new { Id = 1, StartDate = new DateTime(2022, 6, 1), EndDate = new DateTime(2022, 7, 1), CustomerId = 1, LocationId = 1, Discount = 0F },
        new { Id = 2, StartDate = new DateTime(2022, 6, 7), EndDate = new DateTime(2022, 7, 7), CustomerId = 2, LocationId = 2, Discount = 0F }



        );








    }

}


