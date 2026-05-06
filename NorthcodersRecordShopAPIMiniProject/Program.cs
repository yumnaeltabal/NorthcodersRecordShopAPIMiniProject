using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthcodersRecordShopAPIMiniProject.DataBaseContext;
using NorthcodersRecordShopAPIMiniProject.Models;
using NorthcodersRecordShopAPIMiniProject.Repositories;
using NorthcodersRecordShopAPIMiniProject.Services;
using NorthcodersRecordShopAPIMiniProject.Controllers;


namespace NorthcodersRecordShopAPIMiniProject
{
    public class Program
    {
        //private static string connectionString = "Server=DESKTOP-USIJFLT\\SQLEXPRESS01;Database=master;User Id=yumnaeltabal;Password=Beewax12345!;Trust Server Certificate=True";
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AlbumsDbContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IAlbumModel, AlbumRepository>();
            //builder.Services.AddDbContext<AlbumsDbContext>(options =>
            //{
            //    var connection = new SqliteConnection(connectionString);
            //    connection.Open();
            //    options.UseSqlServer(connection.ConnectionString);
            //});
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            //FOR THE http REQUESTS
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
