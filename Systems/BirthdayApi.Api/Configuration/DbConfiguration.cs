using BirthdayApi.Context;
using BirthdayApi.Settings;
namespace BirthdayApi.Api.Configuration
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IApiSettings settings)
        {
            var dbOptionsDelegate = DbContextOptionsFactory.Configure(settings.DbSettings.GetConnectionString);
            services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);
            return services;
        }

        public static WebApplication UseAppDbContext(this WebApplication app)
        {
            DbInit.Execute(app.Services);
            DbSeed.Execute(app.Services);
            return app;
        }
    }
}
