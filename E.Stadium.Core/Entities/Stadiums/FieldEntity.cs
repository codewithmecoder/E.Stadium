using E.Stadium.Core.Entities.FileUploads;

namespace E.Stadium.Core.Entities.Stadiums;

public class FieldEntity
{
    public Guid Id { get; set; }
    public Guid StadiumId { get; set; }
    public int NumberOfPoeple { get; set; }
    public string? Size { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public FieldEntity(
        Guid id,
        Guid stadiumId,
        int numberOfPoeple,
        string? size,
        string? name,
        DateTime? createdAt,
        DateTime? updatedAt,
        bool isActive)
    {
        Id = id;
        StadiumId = stadiumId;
        NumberOfPoeple = numberOfPoeple;
        Size = size;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }

    public StadiumEntity? Stadium { get; set; }
    public IEnumerable<FieldMediaEntity>? FieldMedias { get; set; }
}
