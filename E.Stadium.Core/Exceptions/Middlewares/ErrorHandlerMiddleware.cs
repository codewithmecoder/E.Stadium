using E.Stadium.Abstraction.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace E.Stadium.Core.Exceptions.Middlewares;

public sealed class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var additionalData = new object();
            var statusCode = 400;
            var code = string.Empty;
            if (exception is BaseException)
            {
                additionalData = (exception as BaseException)!.AdditionalData;
                statusCode = (exception as BaseException)!.StatusCode;
                code = (exception as BaseException)!.Code;
            }

            _logger.LogError(exception, $"{exception.Message}{"{@AdditionalData}"}", additionalData);
            await HandleErrorAsync(context, exception, statusCode, code);
        }
    }

    private static Task HandleErrorAsync(HttpContext context, Exception exception, int statusCode, string code)
    {
        var response = new { code, message = exception.Message };
        var payload = JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(payload);
    }
}
