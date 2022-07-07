using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace E.Stadium.Abstraction.Swagger;

public class RemoveVersionParameterFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        OpenApiParameter openApiParameter = operation.Parameters.FirstOrDefault((OpenApiParameter p) => p.Name == "version")!;
        OpenApiParameter openApiParameter2 = operation.Parameters.FirstOrDefault((OpenApiParameter p) => p.Name == "api-version")!;
        if (openApiParameter != null)
        {
            operation.Parameters.Remove(openApiParameter);
        }

        if (openApiParameter2 != null)
        {
            operation.Parameters.Remove(openApiParameter2);
        }
    }
}
