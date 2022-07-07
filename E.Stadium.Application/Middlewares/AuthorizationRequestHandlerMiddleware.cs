using E.Stadium.Core.Exceptions.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace E.Stadium.Application.Middlewares;

public sealed class AuthorizationRequestHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public AuthorizationRequestHandlerMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public Task Invoke(HttpContext context)
    {
        var path = context.Request.Path.Value ?? string.Empty;
        if (path.Contains("api/webhook/"))
            return _next(context);

        //var clientHeader = context.Request.Headers["X-Client"].ToString();
        //AppSettings.ClientHeaders.TryGetValue(clientHeader, out var client);
        //if (string.IsNullOrEmpty(client))
        //    throw new UnAuthorizedRequestException();

        //_logger.LogInformation("Requested Client {@Client}", client);
        return _next(context);
    }
}
