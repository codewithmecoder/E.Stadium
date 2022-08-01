using E.Stadium.Infrastructure.Postgres.FileUploads;
using E.Stadium.Shared.Postgres;
using System.ComponentModel.DataAnnotations.Schema;

namespace E.Stadium.Infrastructure.Postgres.Stadiums;

[Table("fields")]
public class FieldTable:BasePostgresTable
{
    [Column("stadium_id")]
    public Guid StadiumId { get; set; }

    [Column("number_of_poeple")]
    public int NumberOfPoeple { get; set; }

    [Column("size")]
    public string? Size { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    public FieldTable(
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

    public StadiumTable? Stadium { get; set; }
    public IEnumerable<FieldMediaTable>? FieldMedias{ get; set; }
}
