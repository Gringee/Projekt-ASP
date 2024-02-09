using Data;
using Data.Entities;
using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium3.Controllers
{
    [Route("api/photos")]
    [ApiController]
    //http://localhost:7001/api/photos?filter=a
    public class PhotoApiController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoApiController(IPhotoService albumService)
        {
            _photoService = albumService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var albums = _photoService.FindAll();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var album = _photoService.FindById(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Add(model);
                return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Photo model)
        {
            if (id != model.Id)
            {
                return BadRequest("Mismatched photo id in the request body.");
            }

            if (ModelState.IsValid)
            {
                var existingAlbum = _photoService.FindById(id);

                if (existingAlbum == null)
                {
                    return NotFound();
                }

                _photoService.Update(model);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var album = _photoService.FindById(id);

            if (album == null)
            {
                return NotFound();
            }

            _photoService.Delete(album);
            return NoContent();
        }

        [HttpGet("startwith/{letter}")]
        public IActionResult GetByStartingLetter(char letter)
        {
            var filteredAlbums = _photoService.FindAll()
                .Where(a => a.Autor.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(filteredAlbums);
        }
    }
}
