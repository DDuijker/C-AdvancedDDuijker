using AirBnB.Models;
using AirBnB.Models.DTO;

namespace AirBnB.Services
{
    public interface IImageService
    {
        public Task<IEnumerable<Image>> GetAllImages(CancellationToken cancellationToken);
        public Task<IEnumerable<ImageDTO>> GetAllDTOImages(CancellationToken cancellationToken);

        public Task<Image> GetSpecificImage(int imageId, CancellationToken cancellationToken);


    }
}
