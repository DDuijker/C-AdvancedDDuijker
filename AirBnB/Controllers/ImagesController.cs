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

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<IEnumerable<ImageDTO>> GetImages()
        {
            return await _imageService.GetAllDTOImages();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return await _imageService.GetAllImages();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            var image = await _imageService.GetSpecificImage(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }


    }
}
