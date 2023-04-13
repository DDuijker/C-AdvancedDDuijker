using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models
{
    public class Landlord
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual Image? Avatar { get; set; }

        public virtual List<Location> Locations { get; set; }

        public Landlord()
        {
            Locations = new List<Location>();

        }


    }
}
