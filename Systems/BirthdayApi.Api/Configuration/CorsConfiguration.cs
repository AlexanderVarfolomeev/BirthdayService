namespace BirthdayApi.Api.Configuration
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddAppCors(this IServiceCollection services)
        {
            services.AddCors(builder =>
            {
                builder.AddDefaultPolicy(pol =>
                {
                    pol.AllowAnyHeader();
                    pol.AllowAnyMethod();
                    pol.AllowAnyOrigin();
                });
            });

            return services;
        }

        /// <summary>
        /// Use service
        /// </summary>
        /// <param name="app">Application</param>
        public static void UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors();
        }
    }
}
