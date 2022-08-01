namespace E.Stadium.Core.Dto.FieldUploads;

public class ResponseFieldMediaDto
{
    public Guid Id { get; set; }
    public Guid StadiumId { get; set; }
    public string? FieldImageUrl { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public ResponseFieldMediaDto(
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
