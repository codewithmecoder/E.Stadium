using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Entities.Users;
using E.Stadium.Core.Exceptions.User;
using E.Stadium.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace E.Stadium.Application.Commands.Users.Handlers;

public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;

    public ChangePasswordCommandHandler(IUserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task HandleAsync(ChangePasswordCommand command)
    {
        var user = await _userRepository.GetAsync(command.UserId);
        if (user is null)
            throw new UserNotFoundException();
        var isValid = user.ValidatePassword(command.OldPassword, _passwordHasher);
        if (!isValid)
            throw new InvalidOldPasswordException();

        user.SetPassword(command.NewPassword, _passwordHasher);
        user.UpdatedAt = DateTime.UtcNow;
        await _userRepository.UpdateAsync(user);
    }
}
