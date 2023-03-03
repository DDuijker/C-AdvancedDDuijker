namespace AirBnB.Repositories
{
    using AirBnB.Interfaces;
    using AirBnB.Models;
    using Microsoft.EntityFrameworkCore;

    public class LandlordRepository : ILandlordRepository
    {

        private readonly AirBnBContext _context;

        public LandlordRepository(AirBnBContext context)
        {
            _context = context;
        }

        public void Add(Landlord landlord)
        {
            _context.Landlords.Add(landlord);
        }

        public void Delete(int id)
        {
            var landlord = _context.Landlords.Find(id);
            _context.Landlords.Remove(landlord);
        }

        public IEnumerable<Landlord> GetAll()
        {
            return _context.Landlords.ToList();
        }

        public Landlord GetById(int id)
        {
            return _context.Landlords.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Landlord landlord)
        {
            _context.Entry(landlord).State = EntityState.Modified;
        }
    }
}
