namespace AirBnB.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Reservation> Reservations { get; set; }


        public Customer()
        {

        }
        public Customer(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Customer(int id, string firstName, string lastName, string email, List<Reservation> reservations)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Reservations = reservations;
        }
    }
}
