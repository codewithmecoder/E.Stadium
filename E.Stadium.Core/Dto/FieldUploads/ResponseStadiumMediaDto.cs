namespace E.Stadium.Core.Dto.FieldUploads;

public class ResponseStadiumMediaDto
{
    public Guid Id { get; set; }
    public Guid StadiumId { get; set; }
    public string? StadiumImageUrl { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public ResponseStadiumMediaDto(
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
