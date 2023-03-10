//Made by Djoeke Duijker

//s1172016

using AirBnB.Models;

public class Program
{
    public static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.UseUrls("https://localhost:7279");

        Console.WriteLine(builder.Host);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddScoped<LocationRepository>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin());
        }

        //initialize airbnb context
        //AirBnBContext airBnBContext = new AirBnBContext();
        ////add locations to the databasee 
        //LocationRepository locationRepository = new LocationRepository(airBnBContext);
        //LocationsController locationsController = new LocationsController(airBnBContext);

        Location deBoerehoeve = new Location(
            id: 3,
            title: "De Boerehoeve",
            subTitle: "Lekker veel ruimte",
            description: "De camping ligt verscholen achter de boerderij in de polder. Op fietsafstand (5 minuten) liggen het dorpje Nieuwvliet, de zee, het strand, het bos van Erasmus en het natuurgebied de Knokkert.",
            rooms: 5,
            numberOfGuests: 12,
            pricePerDay: 300,
            type: 1,
            features: 0,
            images: null,
            landlord: null,
            landlordForeignKeyId: 0,
            reservations: null
            );

        Location frankiesPenthouse = new Location(
            id: 4,
            title: "Frankie's Penthouse",
            subTitle: "Te gek uitzicht",
            description: "Nee, dit puike penthouse dat al jaren te koop stond en nu is verkocht, is niet de duurste woning van ons land. Bij lange na niet. Wel is de meer dan €30.000 per vierkante meter woonruimte een record in ons land.",
            rooms: 2,
            numberOfGuests: 4,
            pricePerDay: 400,
            type: 0,
            features: 0,
            images: null,
            landlord: null,
            landlordForeignKeyId: 0,
            reservations: null
            );

        //locationRepository.Add(frankiesPenthouse);
        //locationRepository.Add(deBoerehoeve);

        //locationsController.PostLocation(frankiesPenthouse);
        //locationsController.PostLocation(deBoerehoeve);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    //Vragen voor de les
    //Moet ik ook models maken voor bijvoorbeeld reviews als ik een reviewService maak?
    //Hoe kan ik de data van de database in de swagger laten zien?
    //ik had moeite met het opstarten van het programma door een error. Kunt u me daarmee helpen?



}