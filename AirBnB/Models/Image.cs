namespace AirBnB.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsCover { get; set; }

        public Location? Location { get; set; }

        public Landlord? Landlord { get; set; }


    }
}
