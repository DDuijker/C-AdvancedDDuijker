using AirBnB.Interfaces;

namespace AirBnB.Repositories
{

    using AirBnB.Models;
    using Microsoft.EntityFrameworkCore;

    public class ImageRepository : IImageRepository
    {
        private readonly AirBnBContext _context;
        public ImageRepository(AirBnBContext context)
        {
            _context = context;
        }

        public void Add(Image image)
        {
            _context.Images.Add(image);
        }

        public void Delete(int id)
        {
            var image = _context.Images.Find(id);
            _context.Images.Remove(image);
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetById(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Image image)
        {
            _context.Entry(image).State = EntityState.Modified;
        }
    }
}
