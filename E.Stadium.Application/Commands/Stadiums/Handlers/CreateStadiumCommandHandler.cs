using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Entities.FileUploads;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Stadiums.Handlers;

public class CreateStadiumCommandHandler : ICommandHandler<CreateStadiumCommand>
{
    private readonly IStadiumRepository _stadiumRepository;
    private readonly IFileUploadStadiumRepository _stadiumFileRepository;

    public CreateStadiumCommandHandler(IStadiumRepository stadiumRepository, IFileUploadStadiumRepository stadiumFileRepository)
    {
        _stadiumRepository = stadiumRepository;
        _stadiumFileRepository = stadiumFileRepository;
    }

    public async Task HandleAsync(CreateStadiumCommand cmd)
    {
        var stadiumEntity = new StadiumEntity(
            id: cmd.Id,
            userId: cmd.UserId,
            name: cmd.Name,
            description: cmd.Description,
            lat: cmd.Lat,
            lon: cmd.Lon,
            createdAt: cmd.CreatedAt,
            updatedAt: cmd.UpdatedAt,
            address: cmd.Address,
            isActive: cmd.IsActive,
            startTime: cmd.StartTime,
            endTime: cmd.EndTime
            );
        if (cmd.StadiumImageUrls is not null)
        {
            if (cmd.StadiumImageUrls.Any())
            {
                foreach (var url in cmd.StadiumImageUrls)
                {
                    var imageUrl = new StadiumMediaEntity(
                        id: Guid.NewGuid(),
                        stadiumId: cmd.Id,
                        stadiumImageUrl: url,
                        createdAt: DateTime.UtcNow,
                        updatedAt: DateTime.UtcNow,
                        isActive: true
                        );
                    await _stadiumFileRepository.UpdateStadiumImageAsync(imageUrl);
                }
            }
        }
        await _stadiumRepository.CreateAsync(stadiumEntity);
    }
}
