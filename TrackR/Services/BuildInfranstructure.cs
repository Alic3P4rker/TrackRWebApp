using Joyful.API.Services;
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
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}