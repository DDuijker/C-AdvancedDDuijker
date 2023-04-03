using AirBnB.Models.DTO;

namespace AirBnB.Models.Mappers
{
    public class LocationMapper : ILocationMapper
    {
        public LocationDTO Map(Location location)
        {
            string coverUrl = "";
            foreach (Image image in location.Images)
            {
                if (image.IsCover)
                {
                    coverUrl = image.Url;
                }
            }

            return new LocationDTO
            {
                Title = location.Title,
                SubTitle = location.SubTitle,
                Description = location.Description,
                ImageURL = coverUrl,
                LandlordAvatarURL = location.Landlord.Avatar.Url
            };
        }

    }

}
