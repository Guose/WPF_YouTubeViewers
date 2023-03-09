using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YouTubeViewers.EntityFramework;

namespace YouTubeViewers.WPF.Extensions
{
    public static class DbContextExtension
    {
        public static IHostBuilder AddDbContextExtension(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                string? connectionString = context.Configuration.GetConnectionString("SQLite");

                services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                services.AddSingleton<YouTubeViewersDbContextFactory>();
            });
                 return hostBuilder;
        }
    }
}
