using System;
using E.Stadium.Core.Exceptions.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Mip.Farm.Api.Controllers;
[ApiVersion("1")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize]

public abstract class BaseController : ControllerBase
{
    private const string ResourceHeader = "X-Resource";
    private const string IdentityHeader = "X-Identity";


    public BaseController()
    {
    }

    protected ActionResult Accepted(string resource, Guid resourceId)
    {
        if (!string.IsNullOrWhiteSpace(resourceId.ToString()))
        {
            Response.Headers.Add(ResourceHeader, $"{resource}/{resourceId}");
        }

        return base.Accepted();
    }

    protected ActionResult AcceptedWithResource(string resource, string identity)
    {
        if (!string.IsNullOrWhiteSpace(resource))
        {
            Response.Headers.Add(ResourceHeader, $"{resource}");
            Response.Headers.Add(IdentityHeader, $"{identity}");
        }

        return base.Accepted();
    }

    protected ActionResult OkWithResource(Object obj, string resource, string identity)
    {
        if (!string.IsNullOrWhiteSpace(resource))
        {
            Response.Headers.Add(ResourceHeader, $"{resource}");
            Response.Headers.Add(IdentityHeader, $"{identity}");
        }

        return base.Ok(obj);
    }

    protected Guid UserId
    {
        get
        {
            var name = User?.Identity?.Name;
            if (string.IsNullOrWhiteSpace(name))
                return Guid.Empty;

            Guid.TryParse(name, out var id);

            return id;
        }
    }

    protected void TryParseId(string id)
    {
        Guid.TryParse(id, out var validId);
        ValidateUserId(validId);
    }

    protected void TryParseId(string id, out Guid validId)
    {
        Guid.TryParse(id, out validId);
        ValidateUserId(validId);
    }

    protected void ValidateUserId(Guid id)
    {
        if (!id.Equals(UserId))
            throw new InvalidUserIdException(id.ToString());
    }
}
