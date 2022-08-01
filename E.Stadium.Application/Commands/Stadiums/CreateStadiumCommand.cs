using E.Stadium.Abstraction.Commands;

namespace E.Stadium.Application.Commands.Stadiums;

public class CreateStadiumCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Lat { get; set; }
    public decimal? Lon { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Address { get; set; }
    public bool? IsActive { get; set; }
    public List<string>? StadiumImageUrls { get; set; }
    public CreateStadiumCommand(
        Guid id,
        Guid userId,
        string? name,
        string? description,
        decimal? lat,
        decimal? lon,
        DateTime? createdAt,
        DateTime? updatedAt,
        string? address,
        bool? isActive)
    {
        Id = id;
        UserId = userId;
        Name = name;
        Description = description;
        Lat = lat;
        Lon = lon;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Address = address;
        IsActive = isActive;
    }
}
