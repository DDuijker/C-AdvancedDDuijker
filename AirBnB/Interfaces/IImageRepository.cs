namespace AirBnB.Interfaces
{
    using AirBnB.Models;
    public interface IImageRepository
    {
        public Task<IEnumerable<Image>> GetAll(CancellationToken cancellationToken);
        public Task<Image> GetById(int id, CancellationToken cancellationToken);
        void Add(Image image);
        void Update(Image image);
        void Delete(int id);
        void Save();
    }
}
