namespace AirBnB.Interfaces
{
    using AirBnB.Models;

    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetAll(CancellationToken cancellationToken);
        public Task<Location> GetById(int id, CancellationToken cancellationToken);
        void Add(Location location);
        void Update(Location location);
        void Delete(int id);
        void Save();
    }
}
