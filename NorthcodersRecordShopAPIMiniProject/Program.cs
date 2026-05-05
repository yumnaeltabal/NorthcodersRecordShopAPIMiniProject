using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthcodersRecordShopAPIMiniProject.DataBaseContext;
using NorthcodersRecordShopAPIMiniProject.Models;
using System.ComponentModel.Design;


namespace NorthcodersRecordShopAPIMiniProject
{
    public class Program
    {
        private static string connectionString = "Server=DESKTOP-USIJFLT\\SQLEXPRESS01;Database=master;User Id=yumnaeltabal;Password=Beewax12345!;Trust Server Certificate=True";
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddScoped<IAlbums, AlbumsService>();
                builder.Services.AddDbContext<AlbumsDbContext>(options =>
                {
                    var connection = new SqliteConnection(connectionString);
                    connection.Open();
                    options.UseSqlServer(connection.ConnectionString);
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
