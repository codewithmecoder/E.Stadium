using E.Stadium.Abstraction.Commands;
using E.Stadium.Core.Exceptions.Stadiums;
using E.Stadium.Core.Repositories;

namespace E.Stadium.Application.Commands.Stadiums.Handlers;

public class UpdateStadiumCommandHandler : ICommandHandler<UpdateStadiumCommand>
{
    private readonly IStadiumRepository _stadiumRepository;

    public UpdateStadiumCommandHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }
    public async Task HandleAsync(UpdateStadiumCommand cmd)
    {
        var stadium = await _stadiumRepository.GetOnlyStadiumByIdAsync(cmd.Id, cmd.UserId);
        if (stadium == null) throw new StadiumNotFoundException(cmd.Id);
        stadium.Name = cmd.Name;
        stadium.Description = cmd.Description;
        stadium.Lat = cmd.Lat;
        stadium.Lon = cmd.Lon;
        stadium.UpdatedAt = cmd.UpdatedAt;
        stadium.Address = cmd.Address;
        stadium.StartTime = cmd.StartTime;
        stadium.EndTime = cmd.EndTime;
        await _stadiumRepository.UpdateAsync(stadium);
    }
}
