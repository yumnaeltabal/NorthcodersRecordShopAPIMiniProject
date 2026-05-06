using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using NorthcodersRecordShopAPIMiniProject.Models;
using NorthcodersRecordShopAPIMiniProject.Services;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

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
    }
}
