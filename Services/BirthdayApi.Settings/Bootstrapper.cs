using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayApi.Settings
{
    /// <summary>
    /// Класс в котором мы указываем реализацию всех интерфейсов 
    /// </summary>
    public static class Bootstrapper
    {
        public static IServiceCollection AddSettings(this IServiceCollection services)
        {
            services.AddSingleton<ISettingsSource, SettingsSource>();
            services.AddSingleton<IApiSettings, ApiSettings>();
            services.AddSingleton<IDbSettings, DbSettings>();
            services.AddSingleton<IGeneralSettings, GeneralSettings>();
            services.AddSingleton<IWorkerSettings, WorkerSettings>();
            services.AddSingleton<IRabbitMqSettings, RabbitMqSettings>();
            services.AddSingleton<IEmailSettings, EmailSettings>();
            services.AddSingleton<IIdentitySettings, IdentitySettings>();

            return services;
        }
    }
}
