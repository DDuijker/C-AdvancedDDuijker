using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models.DTO
{
    public class CustomerRequestDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
