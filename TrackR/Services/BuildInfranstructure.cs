using TrackR.Abstractions.Repositories;
using TrackR.Repositories;

namespace TrackR.Services;

public static class BuildInfranstructure
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services
    )
    {
        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}