using Cine.Application.Common.Interfaces.Authentication;
using Cine.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Infraestructure;
public static class DependencyInjection{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services)
    {
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}