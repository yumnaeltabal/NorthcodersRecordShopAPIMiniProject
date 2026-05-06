using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using NorthcodersRecordShopAPIMiniProject.Models;
using NorthcodersRecordShopAPIMiniProject.Services;


namespace NorthcodersRecordShopAPIMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var albums = _albumService.GetAllAlbums();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            var album = _albumService.GetAlbumById(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }
        [HttpPost]
        public IActionResult PostNewAlbum(Album album)
        {
            var newAlbum = _albumService.PostNewAlbum(album);
            return CreatedAtAction(nameof(GetAlbumById), new { id = newAlbum.Id }, newAlbum);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAnAlbum(int id)
        {
            var deletedAlbum = _albumService.DeleteAnAlbum(id);
            if (deletedAlbum == null)
            {
                return NotFound();
            }
            return Ok(deletedAlbum);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateAnAlbum(int id, Album updatedAlbum)
        {
            var album = _albumService.UpdateAnAlbum(id, updatedAlbum);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }
    }
}
