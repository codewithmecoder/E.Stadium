using E.Stadium.Infrastructure.Postgres.Stadiums;
using E.Stadium.Shared.Postgres;
using System.ComponentModel.DataAnnotations.Schema;

namespace E.Stadium.Infrastructure.Postgres.FileUploads;

[Table("field_medias")]
public class FieldMediaTable : BasePostgresTable
{
    [Column("field_id")]
    public Guid FieldId { get; set; }
    
    [Column("stadium_image_url")]
    public string? FieldImageUrl { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }
    public FieldTable? Field { get; set; }
    public FieldMediaTable(
        Guid id,
        Guid fieldId,
        string? fieldImageUrl,
        DateTime? createdAt,
        DateTime? updatedAt,
        bool isActive)
    {
        Id = id;
        FieldId = fieldId;
        FieldImageUrl = fieldImageUrl;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }
}
