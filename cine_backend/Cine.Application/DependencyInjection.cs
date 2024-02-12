using Cine.Application.Services.Authentication;
using Cine.Contracts.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Application;
public static class DependencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}