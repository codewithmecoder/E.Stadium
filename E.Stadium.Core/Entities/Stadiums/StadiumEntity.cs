using E.Stadium.Abstraction.Data;
using E.Stadium.Core.Entities.FileUploads;
using E.Stadium.Core.Entities.Users;

namespace E.Stadium.Core.Entities.Stadiums;

public class StadiumEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int TotalFields { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Lat { get; set; }
    public decimal? Lon { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Address { get; set; }
    public bool? IsActive { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }

    public StadiumEntity(
        Guid id,
        Guid userId,
        int totalFields,
        string? name,
        string? description,
        decimal? lat,
        decimal? lon,
        DateTime? createdAt,
        DateTime? updatedAt,
        string? address,
        bool? isActive,
        string? startTime,
        string? endTime)
    {
        Id = id;
        UserId = userId;
        TotalFields = totalFields;
        Name = name;
        Description = description;
        Lat = lat;
        Lon = lon;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Address = address;
        IsActive = isActive;
        StartTime = startTime;
        EndTime = endTime;
    }

    public IEnumerable<FieldEntity> Fields { get; set; } = new List<FieldEntity>();
    public IEnumerable<StadiumMediaEntity> StadiumMedias { get; set; } = new List<StadiumMediaEntity>();
    public UserEntity? User { get; set; }
    public IEnumerable<string>? StadiumImageUrls { get; set; } 
}
