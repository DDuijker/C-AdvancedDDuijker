namespace AirBnB.Interfaces
{

    using AirBnB.Models;
    public interface ILandlordRepository
    {
        IEnumerable<Landlord> GetAll();
        Landlord GetById(int id);
        void Add(Landlord landlord);
        void Update(Landlord landlord);
        void Delete(int id);
        void Save();
    }
}
