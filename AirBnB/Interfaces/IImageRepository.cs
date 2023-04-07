namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface IImageRepository
    {
        public Task<IEnumerable<Image>> GetAll();
        public Task<Image> GetById(int id);
        void Add(Image image);
        void Update(Image image);
        void Delete(int id);
        void Save();
    }
}
