namespace AirBnB.Interfaces
{

    using AirBnB.Models;
    public interface ILandlordRepository
    {
        public Task<IEnumerable<Landlord>> GetAll(CancellationToken cancellationToken);
        public Task<Landlord> GetById(int id, CancellationToken cancellationToken);
        void Add(Landlord landlord);
        void Update(Landlord landlord);
        void Delete(int id);
        void Save();
    }
}
