﻿
namespace AirBnB.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
}
