using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Fields;

public class DeleteFieldCommand : ICommand
{
    public Guid Id { get; set; }

    public DeleteFieldCommand(Guid id)
    {
        Id = id;
    }
}
