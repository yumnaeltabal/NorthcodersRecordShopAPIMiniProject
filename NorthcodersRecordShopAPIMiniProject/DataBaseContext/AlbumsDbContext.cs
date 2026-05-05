using Microsoft.EntityFrameworkCore;
using NorthcodersRecordShopAPIMiniProject.Models;


namespace NorthcodersRecordShopAPIMiniProject.DataBaseContext

{
    public class AlbumsDbContext :DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public AlbumsDbContext(DbContextOptions<AlbumsDbContext> options)
            : base(options)
        {
        }
    }
}
