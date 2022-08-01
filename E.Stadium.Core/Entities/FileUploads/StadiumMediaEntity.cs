using E.Stadium.Abstraction.Data;
using E.Stadium.Core.Entities.Stadiums;

namespace E.Stadium.Core.Entities.FileUploads;

public class StadiumMediaEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid StadiumId { get; set; }
    public string? StadiumImageUrl { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public StadiumEntity? Stadium { get; set; }
    public StadiumMediaEntity(
        Guid id,
        Guid stadiumId,
        string? stadiumImageUrl,
        DateTime? createdAt,
        DateTime? updatedAt,
        bool isActive)
    {
        Id = id;
        StadiumId = stadiumId;
        StadiumImageUrl = stadiumImageUrl;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }
}
