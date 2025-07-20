using Microsoft.EntityFrameworkCore;
using TrackR.Context;

namespace TrackR.Services;

public static class DbContextRegistration
{
    public static IServiceCollection AddTrackRDbContext(
        this IServiceCollection services,
        IConfiguration configuration,
        string? connectionString
    )
    {
        services.AddDbContext<TrackRDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString(connectionString),
                new MySqlServerVersion(new Version(8, 0, 0))
            )
        );

        return services;
    }
}