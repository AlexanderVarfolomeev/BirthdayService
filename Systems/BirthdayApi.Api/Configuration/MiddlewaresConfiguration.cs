namespace BirthdayApi.Api.Configuration
{
    public static class MiddlewaresConfiguration
    {
        public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionsMiddleware>();
            return app;
        }
    }
}
