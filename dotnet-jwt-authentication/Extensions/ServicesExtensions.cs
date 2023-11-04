using dotnet_jwt_authentication.Services;

namespace dotnet_jwt_authentication.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }
}
