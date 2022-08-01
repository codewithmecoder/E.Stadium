using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Users.Handlers;

public class UpdateUserToStadiumRentalHandler : ICommandHandler<UpdateUserToStadiumRental>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserToStadiumRentalHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task HandleAsync(UpdateUserToStadiumRental command)
    {

        await _userRepository.UpdateUserToStadiumRentalAsync(command.Id);
    }
}
