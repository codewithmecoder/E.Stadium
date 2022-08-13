using E.Stadium.Abstraction.Commands;
using E.Stadium.Abstraction.Jwt;
using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Commands.Users;
using E.Stadium.Application.Queries.Users;
using E.Stadium.Core.Dto.Base;
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
            password: dto.Password,
            imageUrl: dto.ImageUrl);
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
    public async Task<ActionResult<UserDto>> LoginAsync([FromBody] LoginDto dto)
    {
        if (dto is null)
            return BadRequest();
        var user = await _userService.LoginAsync(dto.Phone, dto.Region, dto.Password);
        var token = new JsonWebToken { AccessToken = user.CreateToken(_tokenProvider, string.Empty) };
        await _userService.StoreToken(user, token.AccessToken, _protector);
        Response.Cookies.Append("Authorization", $"{token.AccessToken}", new CookieOptions
        {
            HttpOnly = true,
            Domain = "https://estadium.org",
            Expires = DateTimeOffset.Now.AddDays(10),
            IsEssential = true,
            Path = "/",
            Secure = true,
            SameSite = SameSiteMode.None,
            MaxAge = TimeSpan.MaxValue

        });
        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, HttpContext.User);
        //UserDto userReturn = new()
        //{
        //    Id = user.Id.ToString(),
        //    FirstName = user.FirstName,
        //    LastName = user.LastName,
        //    Gender = user.Gender,
        //    DOB = user.DOB,
        //    Phone = user.Phone,
        //    Region = user.Region,
        //    Email = user.Email,
        //    Token = user.Token,
        //    CreatedAt = user.CreatedAt,
        //    UpdatedAt = user.UpdatedAt,
        //    IsActive = user.IsActive,
        //    IsStadiumRental = user.IsStadiumRental,
        //};
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

    /// <summary>
    /// get all users
    /// </summary>
    /// <returns></returns>
    [HttpGet("{isActive}")]
    public async Task<IActionResult> GetAllUsersAsync(bool isActive, [FromQuery] BasePaginateDto dto)
    {
        var query = new GetUsersQuery(isActive, dto.Page, dto.Results);
        var user = await _query.QueryAsync(query);
        return Ok(user);
    }
    /// <summary>
    /// update user
    /// </summary>
    /// <returns></returns>
    [HttpPut("update-user")]
    public async Task<IActionResult> Put([FromBody] UpdateUserDto dto)
    {
        var cmd = new UpdateUserCommand(UserId, dto.FirstName, dto.LastName, dto.Gender, dto.DOB, dto.Email);
        await _command.PerformAsync(cmd);
        return Accepted();
    }

    /// <summary>
    /// active and inactive user
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}/{isActive}")]
    public async Task<IActionResult> InOrActiveUserAsync(Guid id, bool isActive)
    {
        var cmd = new ActiveInActiveUserCommand(id, isActive, UserId);
        await _command.PerformAsync(cmd);
        return Accepted();
    }

    /// <summary>
    /// update normal user to stadium rental
    /// </summary>
    /// <returns></returns>
    [HttpPut("update-to-stadium-rental")]
    public async Task<IActionResult> UpdateToStadiumRental()
    {
        var cmd = new UpdateUserToStadiumRental(UserId);
        await _command.PerformAsync(cmd);
        return Accepted();
    }

    /// <summary>
    /// delete user
    /// </summary>
    /// <returns></returns>
    [HttpDelete("delete-user")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserDto dto)
    {
        var cmd = new DeleteUserCommand(dto.Id, UserId);
        await _command.PerformAsync(cmd);
        return Accepted();
    }

    /// <summary>
    /// change password
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesDefaultResponseType]
    [HttpPut("password")]
    public async Task<ActionResult> ChangePasswordAsync([FromBody] ChangePasswordDto dto)
    {
        var cmd = new ChangePasswordCommand(UserId, dto.OldPassword, dto.NewPassword);
        await _command.PerformAsync(cmd);
        return Accepted();
    }

    [HttpPost("logout")]
    public ActionResult Logout()
    {
        //Append("Authorization", $"{token.AccessToken}", new CookieOptions
        //{
        //    HttpOnly = true
        //});
        Response.Cookies.Delete("Authorization");
        return Accepted();
    }
}
