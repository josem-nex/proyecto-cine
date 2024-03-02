using Cine.Application.Common.Interfaces.Authentication;
using Cine.Application.Common.Interfaces.Persistence;
using Cine.Application.Common.Interfaces.Services;
using Cine.Infrastructure.Authentication;
using Cine.Infrastructure.Persistence;
using Cine.Infrastructure.Persistence.Repositories;
using Cine.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Infraestructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddDbContext<CineDbContext>(options =>
            options.UseSqlServer("Server=localhost;Database=Cine;User Id=sa;Password=Kjkszpj*;TrustServerCertificate=True"));
        // Server=localhost;Database=Cine;User Id=sa;Password=;TrustServerCertificate=True"

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}