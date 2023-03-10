namespace AirBnB.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        public List<Image> Images { get; set; }

        public string Title { get; set; }

        public int Rooms { get; set; }

        public Landlord Landlord { get; set; }

        public int LandlordForeignKeyId { get; set; }

        public List<Reservation> Reservations { get; set; }

        public string SubTitle { get; set; }

        public float PricePerDay { get; set; }

        public int NumberOfGuests { get; set; }

        public int Features { get; set; }

        public string Description { get; set; }

        public int LocationType { get; set; }

        public Location()
        {

        }

        public Location(int id, string title, int rooms, Landlord landlord, int landlordForeignKeyId, string subTitle, float pricePerDay, int numberOfGuests, int features, string description, int type, List<Image> images, List<Reservation> reservations)
        {
            LocationId = id;
            Title = title;
            Rooms = rooms;
            Landlord = landlord;
            LandlordForeignKeyId = landlordForeignKeyId;
            SubTitle = subTitle;
            PricePerDay = pricePerDay;
            NumberOfGuests = numberOfGuests;
            Features = features;
            Description = description;
            LocationType = type;
            Images = images;
            Reservations = reservations;
        }


    }
}
