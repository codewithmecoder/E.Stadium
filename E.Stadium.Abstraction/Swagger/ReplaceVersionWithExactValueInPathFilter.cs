using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace E.Stadium.Abstraction.Swagger;

public class ReplaceVersionWithExactValueInPathFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        OpenApiPaths openApiPaths = new();
        foreach (KeyValuePair<string, OpenApiPathItem> path in swaggerDoc.Paths)
        {
            openApiPaths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
        }

        swaggerDoc.Paths = openApiPaths;
    }
}
