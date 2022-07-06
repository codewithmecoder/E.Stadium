using E.Stadium.Abstraction.Commands;
using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Commands.Users;
using E.Stadium.Core.Dto.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mip.Farm.Api.Controllers;

namespace E.Stadium.Api.Controllers.V1;

[ApiVersion("1")]
public class UserController : BaseController
{
    private readonly ICommandDispatcher _command;
    private readonly IQueryDispatcher _query;

    public UserController(ICommandDispatcher command, IQueryDispatcher query)
    {
        _command = command;
        _query = query;
    }

    [AllowAnonymous]
    [HttpPost()]
    public async Task<ActionResult> SignUpAsync([FromBody] SignUpDto dto)
    {
        var id = Guid.NewGuid();

        var cmd = new SignUpCommand(
            id: id,
            firstName: dto.FirstName,
            lastName: dto.LastName,
            gender: dto.Gender,
            dOB: dto.DOB,
            region: dto.Region,
            phone: dto.Phone,
            password: dto.Password);
        await _command.PerformAsync(cmd);

        return AcceptedWithResource($"user/{id}", id.ToString());
    }
}
