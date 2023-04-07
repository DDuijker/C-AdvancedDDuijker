namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface IReservationRepository
    {
        public Task<IEnumerable<Reservation>> GetAll();
        public Task<Reservation> GetById(int id);
        void Add(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int id);
        void Save();
    }
}
