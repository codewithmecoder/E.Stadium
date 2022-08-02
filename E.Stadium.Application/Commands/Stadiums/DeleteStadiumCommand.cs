using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Stadiums;

public class DeleteStadiumCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }

    public DeleteStadiumCommand(Guid id, Guid ownerId)
    {
        Id = id;
        OwnerId = ownerId;
    }
}
