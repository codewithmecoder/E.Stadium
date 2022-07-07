using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Exceptions.User;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Users.Handlers;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(UpdateUserCommand command)
    {
        var user = await _userRepository.GetAsync(command.UserId);
        if (user is null)
            throw new UserNotFoundException();
        user.FirstName = command.FirstName;
        user.LastName = command.LastName;
        user.Gender = command.Gender;
        user.DOB = command.DOB;
        user.Email = command.Email ?? string.Empty;
        await _userRepository.UpdateAsync(user);
    }
}
