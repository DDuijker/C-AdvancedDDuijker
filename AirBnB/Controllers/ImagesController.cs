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

        /// <summary>
        /// Get all images 
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> GetImages(CancellationToken cancellationToken)
        {
            var images = await _imageService.GetAllDTOImages(cancellationToken);

            if (images == null)
            {
                return NotFound();
            }


            return Ok(images);
        }

        /// <summary>
        /// Get all the images
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionResult representing the result of the operation</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Image>>> GetAllImages(CancellationToken cancellationToken)
        {
            var images = await _imageService.GetAllImages(cancellationToken);

            if (images == null)
            {
                return NotFound();
            }
            return Ok(images);
        }

        /// <summary>
        /// Get a specific image
        /// </summary>
        /// <param name="id">The id of the specific image you want to get</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An IActionresult with the result</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id, CancellationToken cancellationToken)
        {
            var image = await _imageService.GetSpecificImage(id, cancellationToken);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }


    }
}
