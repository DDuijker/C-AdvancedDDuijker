using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models.DTO
{
    public class LandlordDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Avatar { get; set; }
    }
}
