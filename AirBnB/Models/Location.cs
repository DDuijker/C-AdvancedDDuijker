﻿namespace AirBnB.Models
{
    public class Location
    {
        public int Id { get; set; }

        public virtual List<Image> Images { get; set; }

        public string Title { get; set; }

        public int Rooms { get; set; }

        public int? LandlordId { get; set; }

        public virtual Landlord Landlord { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public string SubTitle { get; set; }

        public float PricePerDay { get; set; }

        public int NumberOfGuests { get; set; }

        public string Description { get; set; }

        public Features Features { get; set; }

        public LocationType LocationType { get; set; }



        //public Location(int id, string title, int rooms, Landlord landlord, int landlordForeignKeyId, string subTitle, float pricePerDay, int numberOfGuests, Enum features, string description, Enum LocationType, List<Image> images, List<Reservation> reservations)
        //{
        //    LocationId = id;
        //    Title = title;
        //    Rooms = rooms;
        //    Landlord = landlord;
        //    LandlordForeignKeyId = landlordForeignKeyId;
        //    SubTitle = subTitle;
        //    PricePerDay = pricePerDay;
        //    NumberOfGuests = numberOfGuests;
        //    Features = features;
        //    Description = description;
        //    LocationType = type;
        //    Images = images;
        //    Reservations = reservations;
        //}


    }

}
[Flags]
public enum Features
{
    Smoking = 1,
    PetsAllowed = 2,
    Wifi = 4,
    TV = 8,
    Bath = 16,
    Breakfast = 32
}

public enum LocationType
{
    Appartment,
    Cottage,
    Chalet,
    Room,
    Hotel,
    House
}