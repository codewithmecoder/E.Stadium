using E.Stadium.Core.Entities.Stadiums;

namespace E.Stadium.Core.Entities.FileUploads;

public class FieldMediaEntity
{
    public Guid Id { get; set; }
    public Guid StadiumId { get; set; }
    public string? FieldImageUrl { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public FieldEntity? Field { get; set; }
    public FieldMediaEntity(
        Guid id,
        Guid stadiumId,
        string? fieldImageUrl,
        DateTime? createdAt,
        DateTime? updatedAt,
        bool isActive)
    {
        Id = id;
        StadiumId = stadiumId;
        FieldImageUrl = fieldImageUrl;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }
}
