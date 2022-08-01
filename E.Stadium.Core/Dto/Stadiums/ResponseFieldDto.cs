
using E.Stadium.Core.Dto.FieldUploads;

namespace E.Stadium.Core.Dto.Stadiums;

public class ResponseFieldDto
{
    public Guid Id { get; set; }
    public Guid StadiumId { get; set; }
    public int NumberOfPoeple { get; set; }
    public string? Size { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public ResponseFieldDto(
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

    public IEnumerable<ResponseFieldMediaDto>? FieldMedias { get; set; }
}
