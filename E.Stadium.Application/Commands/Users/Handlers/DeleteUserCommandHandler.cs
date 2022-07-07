using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Exceptions.User;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Users.Handlers;

public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{

    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task HandleAsync(DeleteUserCommand command)
    {
        if (command.Id == command.CurrentUserId) throw new FailToDeleteUserException();
        var user = await _userRepository.GetAsync(command.Id);
        if (user == null) throw new UserNotFoundException();
        await _userRepository.RemoveAsync(user.Id);
    }
}
