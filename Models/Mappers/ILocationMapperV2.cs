using AirBnB.Models.DTO;

namespace AirBnB.Models.Mappers
{
    public interface ILocationMapperV2
    {
        public LocationDTOv2 Map(Location location);
    }
}
