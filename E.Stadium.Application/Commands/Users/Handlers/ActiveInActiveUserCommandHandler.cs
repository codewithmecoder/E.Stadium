using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Exceptions.User;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Users.Handlers;

public class ActiveInActiveUserCommandHandler : ICommandHandler<ActiveInActiveUserCommand>
{
    private readonly IUserRepository _userRepository;

    public ActiveInActiveUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(ActiveInActiveUserCommand command)
    {
        if (command.Id == command.CurrentUserId) throw new FailToDeleteUserException();
        var user = await _userRepository.GetAsync(command.Id);
        if(user == null) throw new UserNotFoundException();

        user.IsActive = command.IsActive;
        await _userRepository.UpdateAsync(user);
    }
}
