namespace AirBnB.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public Customer Customer { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //constructor
        public Reservation()
        {

        }
        public Reservation(int id, int customerId, int locationId, float discount, DateTime startDate, DateTime endDate)
        {
            Id = id;
            CustomerId = customerId;
            LocationId = locationId;
            Discount = discount;
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
