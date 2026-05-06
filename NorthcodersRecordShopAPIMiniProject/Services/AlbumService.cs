using NorthcodersRecordShopAPIMiniProject.Models;
using NorthcodersRecordShopAPIMiniProject.Repositories;

namespace NorthcodersRecordShopAPIMiniProject.Services
{
    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumModel _albumModel;

        public AlbumService(IAlbumModel albumModel)
        {
            _albumModel = albumModel;
        }
        public List<Album> GetAllAlbums()
        {
              return _albumModel.GetAllAlbums();
        }
        public Album GetAlbumById(int id)
        {
            return _albumModel.GetAlbumById(id);
        }
    }
}
