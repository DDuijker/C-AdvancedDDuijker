using System.ComponentModel.DataAnnotations;

namespace AirBnB.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public bool IsCover { get; set; }

    }
}
