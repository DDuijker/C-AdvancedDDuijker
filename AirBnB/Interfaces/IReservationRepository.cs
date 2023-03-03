namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation GetById(int id);
        void Add(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int id);
        void Save();
    }
}
