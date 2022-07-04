using BirthdayApi.BirthdayService;
using BirthdayApi.Settings;
using BirthdayApi.AccountService;
namespace BirthdayApi
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services
                .AddSettings()
                .AddBirthdayService()
                .AddAccountService();
            return services;
        }
    }
}
