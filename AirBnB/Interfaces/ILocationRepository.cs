namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();
        Location GetById(int id);
        void Add(Location location);
        void Update(Location location);
        void Delete(int id);
        void Save();
    }
}
