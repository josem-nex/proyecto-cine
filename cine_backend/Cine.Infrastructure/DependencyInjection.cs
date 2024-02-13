using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Services;
using Cine.Infrastructure.Authentication;
using Cine.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Infraestructure;
public static class DependencyInjection{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}