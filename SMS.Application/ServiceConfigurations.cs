using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SMS.Application;

public static class ServiceConfigurations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}