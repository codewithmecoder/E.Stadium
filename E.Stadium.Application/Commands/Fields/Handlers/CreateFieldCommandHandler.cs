using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Entities.FileUploads;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Fields.Handlers;

public class CreateFieldCommandHandler : ICommandHandler<CreateFieldCommand>
{
    private readonly IFieldRepository _fieldRepository;
    private readonly IFileUploadFieldRepository _fieldFileRepository;

    public CreateFieldCommandHandler(IFieldRepository fieldRepository, IFileUploadFieldRepository fieldFileRepository)
    {
        _fieldRepository = fieldRepository;
        _fieldFileRepository = fieldFileRepository;
    }

    public async Task HandleAsync(CreateFieldCommand cmd)
    {
        var fieldEntity = new FieldEntity(
                id: cmd.Id,
                stadiumId: cmd.StadiumId,
                numberOfPoeple: cmd.NumberOfPoeple,
                size: cmd.Size,
                name: cmd.Name,
                createdAt: cmd.CreatedAt,
                updatedAt: cmd.UpdatedAt,
                isActive: cmd.IsActive
            );
        if (cmd.FieldImageUrls is not null)
        {
            if (cmd.FieldImageUrls.Any())
            {
                foreach (var url in cmd.FieldImageUrls)
                {
                    var imageUrl = new FieldMediaEntity(
                        id: Guid.NewGuid(),
                        stadiumId: cmd.Id,
                        fieldImageUrl: url,
                        createdAt: DateTime.UtcNow,
                        updatedAt: DateTime.UtcNow,
                        isActive: true
                        );
                    await _fieldFileRepository.UpdateFieldImageAsync(imageUrl);
                }
            }
        }
        await _fieldRepository.CreateAsync(fieldEntity);
    }
}
