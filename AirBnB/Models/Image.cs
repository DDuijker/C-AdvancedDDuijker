namespace AirBnB.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string Url { get; set; }

        public bool IsCover { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }

        public Landlord Landlord { get; set; }

    }
}
