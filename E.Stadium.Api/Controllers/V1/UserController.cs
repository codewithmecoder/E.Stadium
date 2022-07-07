using E.Stadium.Abstraction.Commands;
using E.Stadium.Abstraction.Jwt;
using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Commands.Users;
using E.Stadium.Application.Queries.Users;
using E.Stadium.Core.Dto.Users;
using E.Stadium.Core.Entities.Users;
using E.Stadium.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Mip.Farm.Api.Controllers;

namespace E.Stadium.Api.Controllers.V1;

[ApiVersion("1")]
public class UserController : BaseController
{
    private readonly ICommandDispatcher _command;
    private readonly IQueryDispatcher _query;
    private readonly IUserService _userService;
    private readonly ITokenProvider<UserEntity> _tokenProvider;
    private readonly IDataProtector _protector;

    public UserController(
        ICommandDispatcher command,
        IQueryDispatcher query,
        IUserService userService,
        ITokenProvider<UserEntity> tokenProvider,
        IDataProtector protector)
    {
        _command = command;
        _query = query;
        _userService = userService;
        _tokenProvider = tokenProvider;
        _protector = protector;
    }

    /// <summary>
    /// sign a user 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
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

    /// <summary>
    /// login user in 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> LoginAsync([FromBody] LoginDto dto)
    {
        if (dto is null)
            return BadRequest();
        var user = await _userService.LoginAsync(dto.Phone, dto.Region, dto.Password);
        var token = new JsonWebToken { AccessToken = user.CreateToken(_tokenProvider, string.Empty) };
        await _userService.StoreToken(user, token.AccessToken, _protector);

        //var evt = new UserLoggedInEvent(
        //user: user,
        //token: token,
        //oneSignalPlayerId: dto.OneSignalPlayerId,
        //deviceUuid: dto.DeviceUuid ?? string.Empty,
        //deviceVersion: dto.DeviceVersion,
        //deviceName: dto.DeviceName,
        //deviceManufacturer: dto.DeviceManufacturer,
        //publicIp: string.Empty);
        //await _event.PublishAsync(evt);

        return OkWithResource(token, $"user/{user.Id}", user.Id.ToString());
    }

    /// <summary>
    /// get loged-in user information
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<ActionResult<UserDto>> Get()
    {
        var query = new GetUserQuery(UserId);
        var user = await _query.QueryAsync(query);
        return Ok(user);
    }
}
