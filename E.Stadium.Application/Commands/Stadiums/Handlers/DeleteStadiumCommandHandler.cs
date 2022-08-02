using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Stadiums.Handlers;

public class DeleteStadiumCommandHandler : ICommandHandler<DeleteStadiumCommand>
{
    private readonly IStadiumRepository _stadiumRepository;

    public DeleteStadiumCommandHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task HandleAsync(DeleteStadiumCommand command)
    => await _stadiumRepository.DeleteByIdAsync(command.Id, command.OwnerId);
}
