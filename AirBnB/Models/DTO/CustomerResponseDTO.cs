namespace AirBnB.Models.DTO
{
    public class CustomerResponseDTO
    {
        public int Id { get; set; }


        public string Email { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<ReservationResponseDTO> Reservations { get; set; }

    }
}
