using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models.DTO
{
    public class ImageDTO
    {
        [Required]
        public string URL { get; set; }
        [Required]
        public bool IsCover
        {
            get; set;
        }
    }
}