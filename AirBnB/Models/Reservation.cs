using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public virtual Location Location { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }

        public float Discount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }


    }
}
