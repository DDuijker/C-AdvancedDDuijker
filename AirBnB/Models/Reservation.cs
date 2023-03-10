namespace AirBnB.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public Location Location { get; set; }

        public Customer Customer { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //constructor
        public Reservation(int id, float discount, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Discount = discount;
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
