using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models.DTO
{
    public class ReservationRequestDTO
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int LocationId { get; set; }

        public float? Discount
        {
            get; set;

        }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }


    }

}
