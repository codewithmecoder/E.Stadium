using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Exceptions.Fields;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Fields.Handlers;

public class UpdateFieldCommandHandler : ICommandHandler<UpdateFieldCommand>
{
    private readonly IFieldRepository _fieldRepository;

    public UpdateFieldCommandHandler(IFieldRepository fieldRepository, IFileUploadFieldRepository fieldFileRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task HandleAsync(UpdateFieldCommand cmd)
    {
        var fieldEntity = await _fieldRepository.FindByIdAsync(cmd.Id);
        if(fieldEntity == null) throw new FieldNotFoundException(cmd.Id);
        fieldEntity.NumberOfPoeple = cmd.NumberOfPoeple;
        fieldEntity.StadiumId = cmd.StadiumId;
        fieldEntity.Id = cmd.Id;
        fieldEntity.Name = cmd.Name;
        fieldEntity.Size = cmd.Size;
        fieldEntity.UpdatedAt = cmd.UpdatedAt;
        await _fieldRepository.CreateAsync(fieldEntity);
    }
}
