using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Stadiums;

public class UpdateStadiumCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Lat { get; set; }
    public decimal? Lon { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Address { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }

    public UpdateStadiumCommand(
        Guid id,
        Guid userId,
        string? name,
        string? description,
        decimal? lat,
        decimal? lon,
        DateTime? updatedAt,
        string? address,
        string startTime,
        string endTime)
    {
        Id = id;
        UserId = userId;
        Name = name;
        Description = description;
        Lat = lat;
        Lon = lon;
        UpdatedAt = updatedAt;
        Address = address;
        StartTime = startTime;
        EndTime = endTime;
    }
}
