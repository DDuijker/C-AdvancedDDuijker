namespace AirBnB.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsCover { get; set; }

        public virtual Location Location { get; set; }

        public virtual Landlord? Landlord { get; set; }


    }
}
