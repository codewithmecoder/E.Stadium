using E.Stadium.Core.Dto.FieldUploads;

namespace E.Stadium.Core.Dto.Stadiums;

public class ResponseStadiumDto
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
    public IEnumerable<ResponseFieldDto>? Fields { get; set; }
    public IEnumerable<ResponseStadiumMediaDto>? StadiumMedias { get; set; }

    public ResponseStadiumDto(
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
        bool? isActive)
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
    }
}
