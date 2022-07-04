namespace BirthdayApi.Api.Configuration
{
    public static class HealthConfiguration
    {
        public static IServiceCollection AddAppHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }

        public static IApplicationBuilder UseAppHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health");

            return app;
        }
    }
}
