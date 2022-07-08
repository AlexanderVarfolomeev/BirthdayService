using BirthdayApi.EmailSender;

namespace BirthdayApi.EmailSender;

using BirthdayApi.EmailService;
using BirthdayApi.RabbitMQService;
using BirthdayApi.Settings;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddSettings()
            .AddEmailSender()
            .AddRabbitMq()
            .AddSingleton<ITaskExecutor, TaskExecutor>();
            ;

        return services;
    }
}
 



