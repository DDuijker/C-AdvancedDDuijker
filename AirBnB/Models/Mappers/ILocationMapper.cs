using AirBnB.Models.DTO;

namespace AirBnB.Models.Mappers
{
    public interface ILocationMapper
    {
        public LocationDTO Map(Location location);
    }
}
