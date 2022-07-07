using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace E.Stadium.Infrastructure.Swagger.CustomizeHeaders;

public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Client",
            In = ParameterLocation.Header,
            Description = "Authorization header",
            Required = false,

            Schema = new OpenApiSchema
            {
                Type = "String",
                Default = new OpenApiString("YnBJ7QgZ")
            }
        });

    }
}
