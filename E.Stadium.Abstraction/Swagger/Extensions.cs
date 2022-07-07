using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace E.Stadium.Abstraction.Swagger;

public static class Extensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, string docFilename, string appName = "")
    {
        services.AddSwaggerGen(delegate (SwaggerGenOptions c)
        {
            IApiVersionDescriptionProvider requiredService = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (ApiVersionDescription apiVersionDescription in requiredService.ApiVersionDescriptions)
            {
                c.SwaggerDoc(apiVersionDescription.GroupName, new OpenApiInfo
                {
                    Title = appName + " Development APIs",
                    Version = $"v{apiVersionDescription.ApiVersion}"
                });
            }

            c.ExampleFilters();
            c.OperationFilter<AddResponseHeadersFilter>(Array.Empty<object>());
            c.OperationFilter<RemoveVersionParameterFilter>(Array.Empty<object>());
            c.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>(Array.Empty<object>());
            Dictionary<string, IEnumerable<string>> dictionary = new()
            {
                {
                    "Bearer",
                    Array.Empty<string>()
                } };
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                } });
            string filePath = Path.Combine(AppContext.BaseDirectory, docFilename);
            c.IncludeXmlComments(filePath);
            c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(Array.Empty<object>());
        });
        services.AddSwaggerGenNewtonsoftSupport();
        services.AddSwaggerExamplesFromAssemblyOf<TestExample>();
        return services;
    }
}
