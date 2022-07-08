using BirthdayApi.BirthdayService;
using BirthdayApi.Settings;
using BirthdayApi.AccountService;
using BirthdayApi.EmailService;
using BirthdayApi.RabbitMQService;

namespace BirthdayApi
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services
                .AddSettings()
                .AddBirthdayService()
                .AddAccountService()
                .AddEmailSender()
                .AddRabbitMq();
            return services;
        }
    }
}
