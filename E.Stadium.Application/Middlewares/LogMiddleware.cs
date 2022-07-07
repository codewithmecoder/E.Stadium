using E.Stadium.Core;
using E.Stadium.Core.Exceptions.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace E.Stadium.Application.Middlewares;

public class LogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public LogMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public Task Invoke(HttpContext context)
    {
        var clientId = context.Request.Headers["X-ClientId"].ToString();
        var clientIp = context.Request.Headers["X-Real-IP"].ToString();
        var userId = context.User.Identity?.Name ?? string.Empty;

        var culture = context.Request.Headers["language"].ToString();

        //AppSettings.CurrentCulture = string.IsNullOrWhiteSpace(culture) ? "en" : culture;

        _logger.LogInformation("Requested from ip: {@IP}, client id: {@ClientId}, user id: {@UserId}", clientIp ?? string.Empty, clientId ?? string.Empty, userId ?? string.Empty);

        _ = DateTime.TryParse(context.Request.Headers["X-Local-Time"].ToString(), result: out var local);
        AppSettings.ClientLocalTime = local;

        _ = DateTime.TryParse(context.Request.Headers["X-Utc-Time"].ToString(), result: out var utc);
        AppSettings.ClientUtcTime = utc.ToUniversalTime();

        return _next(context);
    }

}
