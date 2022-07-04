using BirthdayApi.Settings;
using Swashbuckle;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using BirthdayApi.Common;

namespace BirthdayApi.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        private static string AppTitle = "DSR NetSchool API";


        public static IServiceCollection AddAppSwagger(this IServiceCollection services, IApiSettings settings)
        {
            if (!settings.GeneralSettings.SwaggerVisible)
                return services;

            services.AddOptions<SwaggerGenOptions>();

            services.AddSwaggerGen(options =>
            {
                options.SupportNonNullableReferenceTypes();

                options.UseInlineDefinitionsForEnums();

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                options.OperationFilter<SwaggerDefaultValues>();


                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = IdentityServerAuthenticationDefaults.AuthenticationScheme,
                    Type = SecuritySchemeType.OAuth2,
                    Scheme = "oauth2",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri($"{settings.IdentityServer.Url}/connect/token"),
                            Scopes = new Dictionary<string, string>
                        {
                            {AppScopes.BirthdayRead, "BooksRead"},
                            {AppScopes.BirthdayWrite, "BooksWrite"}
                        }
                        },
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri($"{settings.IdentityServer.Url}/connect/token"),
                            Scopes = new Dictionary<string, string>
                        {
                            {AppScopes.BirthdayRead, "BooksRead"},
                            {AppScopes.BirthdayWrite, "BooksWrite"}
                        }
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }



        public static void UseAppSwagger(this WebApplication app)
        {
            var settings = app.Services.GetService<IApiSettings>();
            var provider = app.Services.GetService<IApiVersionDescriptionProvider>();

            if (!settings.GeneralSettings.SwaggerVisible)
                return;

            app.UseSwagger(options =>
            {
              //  options.RouteTemplate = "api/{documentname}/api.yaml";
            });

            app.UseSwaggerUI(
                options =>
                {
                   // options.RoutePrefix = "api";

                    options.DocExpansion(DocExpansion.List);
                    options.DefaultModelsExpandDepth(-1);
                    options.OAuthAppName(AppTitle);

                // ToDo: Remove for production
                    options.OAuthClientId(settings.IdentityServer.ClientId);
                    options.OAuthClientSecret(settings.IdentityServer.ClientSecret);
                }
            );
        }

        private class SwaggerDefaultValues : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var apiDescription = context.ApiDescription;

                operation.Deprecated |= apiDescription.IsDeprecated();

                if (operation.Parameters == null)
                    return;

                foreach (var parameter in operation.Parameters)
                {
                    var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                    parameter.Description ??= description.ModelMetadata?.Description;

                    if (parameter.Schema.Default == null && description.DefaultValue != null)
                        parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());

                    parameter.Required |= description.IsRequired;
                }
            }
        }
    }
}
