using NorthcodersRecordShopAPIMiniProject.Models;
using System.Text.Json;
using NorthcodersRecordShopAPIMiniProject.DataBaseContext;


namespace NorthcodersRecordShopAPIMiniProject.Repositories
{
    public interface IAlbumModel
    {
        public List<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public Album PostNewAlbum(Album album);
        public Album DeleteAnAlbum(int id);
        public Album UpdateAnAlbum(int id, Album updatedAlbum);
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
        public Album PostNewAlbum(Album album)
        {
            using (_db)
            {
                _db.Add(album);
                _db.SaveChanges();
                return _db.Albums.ToList().Where(a => a.Artist == album.Artist && a.Title == album.Title).FirstOrDefault();
            }
            //var albumsFile = File.ReadAllText("Resources\\Albums.json");
            //List<Album> albums = JsonSerializer.Deserialize<List<Album>>(albumsFile);
            //var newAlbum = new Album
            //{
            //    Id = albums.Max(album => album.Id) + 1,
            //    Title = "New Album",
            //    Artist = "New Artist",
            //    Genre = "New Genre",
            //};
            //albums.Add(newAlbum);
            //string updatedAlbumsJson = JsonSerializer.Serialize(albums, new JsonSerializerOptions { WriteIndented = true });
            //File.WriteAllText("Resources\\Albums.json", updatedAlbumsJson);
            //return newAlbum;
        }
        public Album DeleteAnAlbum(int id)
        {
            using (_db)
            {
                var albumToDelete = _db.Albums.Find(id);
                if (albumToDelete != null)
                {
                    _db.Albums.Remove(albumToDelete);
                    _db.SaveChanges();
                }
                return albumToDelete;
            }
            //var albumsFile = File.ReadAllText("Resources\\Albums.json");
            //List<Album> albums = JsonSerializer.Deserialize<List<Album>>(albumsFile);
            //var albumToDelete = albums.FirstOrDefault(album => album.Id == id);
            //if (albumToDelete != null)
            //{
            //    albums.Remove(albumToDelete);
            //    string updatedAlbumsJson = JsonSerializer.Serialize(albums, new JsonSerializerOptions { WriteIndented = true });
            //    File.WriteAllText("Resources\\Albums.json", updatedAlbumsJson);
            //}
            //return albumToDelete;
        }
        public Album UpdateAnAlbum(int id, Album updatedAlbum)
        {
            using (_db)
            {
                var albumToUpdate = _db.Albums.Find(id);
                if (albumToUpdate != null)
                {
                    albumToUpdate.Title = updatedAlbum.Title;
                    albumToUpdate.Artist = updatedAlbum.Artist;
                    albumToUpdate.Genre = updatedAlbum.Genre;
                    _db.SaveChanges();
                }
                return albumToUpdate;
            }
            //var albumsFile = File.ReadAllText("Resources\\Albums.json");
            //List<Album> albums = JsonSerializer.Deserialize<List<Album>>(albumsFile);
            //var albumToUpdate = albums.FirstOrDefault(album => album.Id == id);
            //if (albumToUpdate != null)
            //{
            //    albumToUpdate.Title = updatedAlbum.Title;
            //    albumToUpdate.Artist = updatedAlbum.Artist;
            //    albumToUpdate.Genre = updatedAlbum.Genre;
            //    string updatedAlbumsJson = JsonSerializer.Serialize(albums, new JsonSerializerOptions { WriteIndented = true });
            //    File.WriteAllText("Resources\\Albums.json", updatedAlbumsJson);
            //}
            //return albumToUpdate;
        }
    }
}