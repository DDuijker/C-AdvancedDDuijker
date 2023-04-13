namespace AirBnB.Models.DTO
{
    public class LocationDetailDTO
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public int Rooms { get; set; }

        public int NumberOfGuests { get; set; }
        public int PricePerDay { get; set; }

        public int Type { get; set; }

        public int Features { get; set; }

        public List<ImageDTO> Images { get; set; }

        public LandlordDTO Landlord { get; set; }
    }
}
