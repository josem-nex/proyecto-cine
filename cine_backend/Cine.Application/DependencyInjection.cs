using System.Reflection;
using Cine.Application.Models.Movies.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}