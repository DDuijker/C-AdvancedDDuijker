namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetAll();
        public Task<Location> GetById(int id);
        void Add(Location location);
        void Update(Location location);
        void Delete(int id);
        void Save();
    }
}
