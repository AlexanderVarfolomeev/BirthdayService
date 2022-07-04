using BirthdayApi.Settings;
namespace BirthdayApi.Identity
{
    public static class Bootstrapper
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddSettings();
        }
    }
}
