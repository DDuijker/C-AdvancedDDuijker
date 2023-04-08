
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
            return (await _imageRepository.GetAll(cancellationToken)).Select(image => _mapper.Map<Image, ImageDTO>(image));
        }

        public async Task<IEnumerable<Image>> GetAllImages(CancellationToken cancellationToken)
        {
            return await _imageRepository.GetAll(cancellationToken);
        }

        public async Task<Image> GetSpecificImage(int imageId, CancellationToken cancellationToken)
        {
            return await _imageRepository.GetById(imageId, cancellationToken);
        }
    }
}
