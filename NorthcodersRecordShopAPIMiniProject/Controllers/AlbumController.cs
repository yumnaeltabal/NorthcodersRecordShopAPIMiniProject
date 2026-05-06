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
        private readonly AlbumService _albumService;

        public AlbumController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        [OutputCache]
        public List<Album> GetAllAlbums()
        {
            return _albumService.GetAllAlbums();
        }
    }
}
