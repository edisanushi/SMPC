using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string dbConnectionString = configuration.GetConnectionString("SMPC");

        services.AddDbContext<SmpcDbContext>((options) =>
        {
            options.UseSqlServer(dbConnectionString);
        });

        services.AddScoped<ITestRepository, TestRepository>();

        return services;
    }
}
