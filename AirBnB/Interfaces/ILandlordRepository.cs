namespace AirBnB.Interfaces
{

    using AirBnB.Models;
    public interface ILandlordRepository
    {
        public Task<IEnumerable<Landlord>> GetAll();
        public Task<Landlord> GetById(int id);
        void Add(Landlord landlord);
        void Update(Landlord landlord);
        void Delete(int id);
        void Save();
    }
}
