using NorthcodersRecordShopAPIMiniProject.Models;
using NorthcodersRecordShopAPIMiniProject.Repositories;

namespace NorthcodersRecordShopAPIMiniProject.Services
{
    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        Album PostNewAlbum(Album album);
        Album DeleteAnAlbum(int id);
        Album UpdateAnAlbum(int id, Album updatedAlbum);
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
       public Album PostNewAlbum(Album album)
       {
            return _albumModel.PostNewAlbum(album);
       }
        public Album DeleteAnAlbum(int id)
        {
            return _albumModel.DeleteAnAlbum(id);
        }
        public Album UpdateAnAlbum(int id, Album updatedAlbum)
        {
            return _albumModel.UpdateAnAlbum(id, updatedAlbum);
        }
    }
}
