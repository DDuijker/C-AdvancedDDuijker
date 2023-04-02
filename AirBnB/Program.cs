//Made by Djoeke Duijker

//s1172016

using AirBnB;
using AirBnB.Interfaces;
using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Repositories;
using AirBnB.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ILocationRepository, LocationRepository>();
        builder.Services.AddScoped<ILocationService, LocationService>();
        //Mapping
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationDTO>());
        var mapper = config.CreateMapper();
        builder.Services.AddAutoMapper(typeof(MapperProfile));
        //builder.Services.AddAutoMapper(typeof(Program));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin());
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}