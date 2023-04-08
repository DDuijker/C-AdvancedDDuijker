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
            if (location != null)
            {
                _context.Locations.Remove(location);
            }
        }
        public async Task<IEnumerable<Location>> GetAll(CancellationToken cancellationToken)
        {

            return (await _context.Locations.Include(p => p.Landlord).Include(p => p.Images).ToListAsync(cancellationToken));
        }
        public async Task<Location> GetById(int id, CancellationToken cancellationToken)
        {
            var location = _context.Locations.FindAsync(new object[] { id }, cancellationToken);
            return await location;

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
