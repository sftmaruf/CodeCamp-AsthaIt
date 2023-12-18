using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Application.Common.Interfaces;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Data.Repositories;
using SMS.Infrastructure.Data.UnitOfWorks;

namespace SMS.Infrastructure;

public static class ServiceConfigurations
{
    private const string connectionStringKey = "SMS.API";

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(connectionStringKey);

        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IBatchRepository, BatchRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}