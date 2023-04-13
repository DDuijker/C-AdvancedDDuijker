using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models
{
    public class Location
    {
        public int Id { get; set; }

        public virtual List<Image> Images { get; set; }
        [Required]
        public string Title { get; set; }

        public int Rooms { get; set; }

        public int? LandlordId { get; set; }
        [Required]
        public virtual Landlord Landlord { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public string SubTitle { get; set; }
        [Required]
        public float PricePerDay { get; set; }

        public int NumberOfGuests { get; set; }

        public string Description { get; set; }
        [Required]
        public Features Features { get; set; }

        public LocationType LocationType { get; set; }

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