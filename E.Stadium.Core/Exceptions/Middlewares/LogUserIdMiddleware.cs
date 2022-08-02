using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace E.Stadium.Core.Exceptions.Middlewares;

public class LogUserIdMiddleware
{
    private readonly RequestDelegate _next;

    public LogUserIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext context)
    {
        LogContext.PushProperty("UserId", context.User?.Identity?.Name);
        return _next(context);
    }
}
