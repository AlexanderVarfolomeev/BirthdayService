namespace BirthdayApi.Identity;

using BirthdayApi.Context;
using BirthdayApi.Domain;
using Microsoft.AspNetCore.Identity;
using BirthdayApi.Settings;
using Microsoft.Extensions.DependencyInjection;

public static class DbConfiguration
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IDbSettings settings)
    {
        var dbOptionsDelegate = DbContextOptionsFactory.Configure(settings.GetConnectionString);

        services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

        return services;
    }

    public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
    {
        return app;
    }
}
