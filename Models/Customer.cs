using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual List<Reservation> Reservations { get; set; }


    }
}
