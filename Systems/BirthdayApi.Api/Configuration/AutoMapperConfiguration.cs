using BirthdayApi.Common;
namespace BirthdayApi.Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            AutoMapperRegisterServices.Register(services);
            return services;
        }
    }
}
