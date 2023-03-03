namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface IImageRepository
    {
        IEnumerable<Image> GetAll();
        Image GetById(int id);
        void Add(Image image);
        void Update(Image image);
        void Delete(int id);
        void Save();
    }
}
