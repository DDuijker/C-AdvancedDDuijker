﻿namespace AirBnB.Repositories
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

        public async Task<IEnumerable<Landlord>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _context.Landlords.ToListAsync(cancellationToken);
            return result;
        }

        public async Task<Landlord> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Landlords.SingleOrDefaultAsync(l => l.Id == id, cancellationToken);
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
