
using AirBnB.Interfaces;
using AirBnB.Models;
using AirBnB.Models.DTO;
using AutoMapper;
namespace AirBnB.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ImageDTO>> GetAllDTOImages(CancellationToken cancellationToken)
        {
            try
            {
                return (await _imageRepository.GetAll(cancellationToken)).Select(image => _mapper.Map<Image, ImageDTO>(image));
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while getting all DTO images.", e);
            }

        }

        public async Task<IEnumerable<Image>> GetAllImages(CancellationToken cancellationToken)
        {
            return await _imageRepository.GetAll(cancellationToken);
        }

        public async Task<Image> GetSpecificImage(int imageId, CancellationToken cancellationToken)
        {
            try
            {
                if (imageId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(imageId), "Image ID must be a positive integer.");
                }

                var image = await _imageRepository.GetById(imageId, cancellationToken);

                if (image == null)
                {
                    throw new ArgumentException($"Image with ID {imageId} does not exist.", nameof(imageId));
                }

                return image;
            }
            catch (Exception ex)
            {
                // Log the error message here or throw a custom exception if needed.
                throw new Exception("An error occurred while getting the specific image.", ex);
            }
        }
    }
}
