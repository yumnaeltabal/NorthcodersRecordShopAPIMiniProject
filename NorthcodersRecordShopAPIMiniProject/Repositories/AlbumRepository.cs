using NorthcodersRecordShopAPIMiniProject.Models;
using System.Text.Json;
using NorthcodersRecordShopAPIMiniProject.DataBaseContext;


namespace NorthcodersRecordShopAPIMiniProject.Repositories
{
    public interface IAlbumModel
    {
        public List<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
    }
    public class AlbumRepository : IAlbumModel
    {
        private AlbumsDbContext _db;
        public AlbumRepository(AlbumsDbContext db)
        {
            _db = db;
        }
        public List<Album> GetAllAlbums()
        {
            using (_db)
            {
                return _db.Albums.ToList();
            }
            //var albumsFile = File.ReadAllText("Resources\\Albums.json");
            //List<Album> albums = JsonSerializer.Deserialize<List<Album>>(albumsFile);

            //return albums;
        }
        public Album GetAlbumById(int id)
        {
            using (_db)
            {
                return _db.Albums.Find(id);
            }
            //var albumsFile = File.ReadAllText("Resources\\Albums.json");
            //List<Album> albums = JsonSerializer.Deserialize<List<Album>>(albumsFile);

            //return albums.FirstOrDefault(album => album.Id == id);
        }
    }
}