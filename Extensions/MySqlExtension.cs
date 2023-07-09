using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Extensions;

public static class MySqlExtension
{
    public static void ConfigureMySql(this IServiceCollection services)
    {
        var envirronment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var configuration = (IConfiguration)services.BuildServiceProvider().GetService(typeof(IConfiguration));

        var connectionString = configuration.GetConnectionString("MySqlDatabase");

        services.AddDbContext<MovieContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
