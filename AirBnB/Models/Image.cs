namespace AirBnB.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsCover { get; set; }

        public Location? Location { get; set; }

        public Landlord? Landlord { get; set; }

        //make constructor
        public Image()
        {

        }
        public Image(int id, string url, bool isCover, Location location, Landlord landlord)
        {
            Id = id;
            Url = url;
            IsCover = isCover;
            Location = location;
            Landlord = landlord;
        }
    }
}
