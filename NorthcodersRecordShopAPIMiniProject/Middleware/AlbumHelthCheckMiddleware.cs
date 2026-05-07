using Microsoft.Extensions.Diagnostics.HealthChecks;
using NorthcodersRecordShopAPIMiniProject.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using NorthcodersRecordShopAPIMiniProject.DataBaseContext;

namespace NorthcodersRecordShopAPIMiniProject.Middleware
{
    public class AlbumHealthCheck : IHealthCheck
    {
        private readonly AlbumsDbContext _dbContext;

        public AlbumHealthCheck(AlbumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken next)
        {
            try
            {
                var connectionAvailable = await _dbContext.Database.CanConnectAsync(next);

                if (!connectionAvailable)
                {
                    return HealthCheckResult.Unhealthy("Can not connect to the database SORRY!");
                }

                int albumCount = await _dbContext.Albums.CountAsync(next);

                if (albumCount > 0)
                {
                    return HealthCheckResult.Healthy($"Connection successfull to the Database!! There are: {albumCount} Albums available right now.");
                }
                return HealthCheckResult.Unhealthy("We cjust ggot hacked.. there are no albums in the database.");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"There was an error... {ex.Message}");
            }
        }
    }
}
    

