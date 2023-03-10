namespace AirBnB.Models
{
    public class Landlord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int AvatarId { get; set; }

        public Image Avatar { get; set; }

        public List<Location> Locations { get; set; }

        //constructor
        public Landlord()
        {

        }
        public Landlord(int id, string firstName, string lastName, int age, string email, string phone, int avatarId, Image avatar, List<Location> locations)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Phone = phone;
            AvatarId = avatarId;
            Avatar = avatar;
            Locations = locations;
        }
    }
}
