using E.Stadium.Infrastructure.Postgres.Stadiums;
using E.Stadium.Shared.Postgres;
using System.ComponentModel.DataAnnotations.Schema;

namespace E.Stadium.Infrastructure.Postgres.FileUploads;

[Table("stadium_medias")]
public class StadiumMediaTable : BasePostgresTable
{
    [Column("stadium_id")]
    public Guid StadiumId { get; set; }

    [Column("stadium_image_url")]
    public string? StadiumImageUrl { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }
    public StadiumTable? Stadium { get; set; }
    public StadiumMediaTable(Guid id, Guid stadiumId, string? stadiumImageUrl, DateTime? createdAt, DateTime? updatedAt, bool isActive)
    {
        Id = id;
        StadiumId = stadiumId;
        StadiumImageUrl = stadiumImageUrl;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }
}
