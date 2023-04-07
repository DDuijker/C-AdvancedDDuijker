using AirBnB.Models;
using AirBnB.Models.DTO;

namespace AirBnB.Services
{
    public interface IImageService
    {
        public Task<IEnumerable<Image>> GetAllImages();
        public Task<IEnumerable<ImageDTO>> GetAllDTOImages();

        public Task<Image> GetSpecificImage(int imageId);


    }
}
