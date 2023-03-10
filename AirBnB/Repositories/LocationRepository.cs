namespace AirBnB.Repositories
{
    using AirBnB.Interfaces;
    using AirBnB.Models;
    using Microsoft.EntityFrameworkCore;

    public class LocationRepository : ILocationRepository
    {

        private readonly AirBnBContext _context;
        public LocationRepository(AirBnBContext context)
        {
            _context = context;
        }
        public void Add(Location location)
        {
            _context.Locations.Add(location);
        }
        public void Delete(int id)
        {
            var location = _context.Locations.Find(id);
            _context.Locations.Remove(location);
        }
        public IEnumerable<Location> GetAll()
        {

            return _context.Locations.ToList();
        }
        public Location GetById(int id)
        {
            return _context.Locations.Find(id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
        }
    }


}
