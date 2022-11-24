using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task.Application.Common.Interfaces;

namespace Task.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = "";
        
        connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"
            ? configuration["ProductionDbConnection"]
            : configuration["DevelopDbConnection"];

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddScoped<IApplicationContext, ApplicationContext>();

        return services;
    }
}