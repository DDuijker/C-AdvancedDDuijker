using AirBnB.Models;
using AirBnB.Models.DTO;
using AirBnB.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]

    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<IEnumerable<ImageDTO>> GetImages(CancellationToken cancellationToken)
        {
            return await _imageService.GetAllDTOImages(cancellationToken);
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Image>> GetAllImages(CancellationToken cancellationToken)
        {
            return await _imageService.GetAllImages(cancellationToken);
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id, CancellationToken cancellationToken)
        {
            var image = await _imageService.GetSpecificImage(id, cancellationToken);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }


    }
}
