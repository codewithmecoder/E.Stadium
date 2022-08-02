using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Fields.Handlers;

public class DeleteFieldCommandHandler : ICommandHandler<DeleteFieldCommand>
{
    private readonly IFieldRepository _fieldRepository;

    public DeleteFieldCommandHandler(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public Task HandleAsync(DeleteFieldCommand command)
    => _fieldRepository.DeleteByIdAsync(command.Id);
}
