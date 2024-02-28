using Cine.Api.Common.Errors;
using Cine.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Cine.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CineProblemDetailsFactory>();
        services.AddMapping();



        return services;
    }
}