using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BirthdayApi.BirthdayService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBirthdayService(this IServiceCollection services)
        {
            services.AddSingleton<IBirthdayService, BirthdayService>();
            return services;
        }
    }
}
