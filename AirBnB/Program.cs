//Made by Djoeke Duijker

//s1172016

using AirBnB;
using AirBnB.Interfaces;
using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Options;
using AirBnB.Repositories;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<AirBnBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("AirBnBContext")));

        builder.WebHost.UseUrls("https://localhost:7279");

        Console.WriteLine(builder.Host);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "AirBnB API", Version = "v1" });
            options.SwaggerDoc("v2", new OpenApiInfo { Title = "AirBnB API", Version = "v2" });
        });
        builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        //configure repositories
        builder.Services.AddScoped<IImageRepository, ImageRepository>();
        builder.Services.AddScoped<ILocationRepository, LocationRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ILandlordRepository, LandlordRepository>();
        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

        //configure services
        builder.Services.AddScoped<ILocationService, LocationService>();
        builder.Services.AddScoped<IImageService, ImageService>();
        builder.Services.AddScoped<IReservationService, ReservationService>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        //prevent circular reference
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });


        //Mapping
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationDTO>());
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<LocationDTOv2, Location>());
        var config3 = new MapperConfiguration(cfg => cfg.CreateMap<DateOnly, UnAvailableDatesDTO>());
        var mapper = config.CreateMapper();
        var mapper2 = config2.CreateMapper();
        var mapper3 = config3.CreateMapper();
        builder.Services.AddAutoMapper(typeof(MapperProfile));
        builder.Services.AddAutoMapper(typeof(Program));

        //Add Api-versioning
        builder.Services.AddApiVersioning(setup =>
        {
            setup.ReportApiVersions = true;
            setup.AssumeDefaultVersionWhenUnspecified = true;
            setup.DefaultApiVersion = new ApiVersion(1, 0);
            setup.ApiVersionReader = new QueryStringApiVersionReader("api-version");
        });

        builder.Services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json?api-version=2", description.GroupName.ToUpperInvariant());
                }
            });

            app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin());
        }

        app.UseApiVersioning();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}