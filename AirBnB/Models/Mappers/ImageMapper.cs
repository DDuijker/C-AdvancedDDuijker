using AirBnB.Models.DTO;

namespace AirBnB.Models.Mappers
{
    public class ImageMapper : IImageMapper
    {
        public ImageDTO Map(Image image)
        {
            return new ImageDTO
            {
                URL = image.Url,
                IsCover = image.IsCover
            };
        }
    }
}
