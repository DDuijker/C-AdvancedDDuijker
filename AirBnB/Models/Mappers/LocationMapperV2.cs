using AirBnB.Models.DTO;

namespace AirBnB.Models.Mappers
{
    public class LocationMapperV2 : ILocationMapperV2
    {
        public LocationDTOv2 Map(Location location)
        {
            string coverUrl = "";

            foreach (Image image in location.Images)
            {
                if (image.IsCover)
                {
                    coverUrl = image.Url;
                }
            }

            return new LocationDTOv2
            {
                Title = location.Title,
                SubTitle = location.SubTitle,
                Description = location.Description,
                ImageURL = coverUrl,
                LandlordAvatarURL = location.Landlord.Avatar.Url,
                Price = location.PricePerDay, // Set Price to the value from the Location object
                Type = location.LocationType // Set Type to the value from the Location object
            };
        }
    }
}
