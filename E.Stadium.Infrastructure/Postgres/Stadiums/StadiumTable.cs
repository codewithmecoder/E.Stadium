using E.Stadium.Infrastructure.Postgres.FileUploads;
using E.Stadium.Infrastructure.Postgres.User;
using E.Stadium.Shared.Postgres;
using System.ComponentModel.DataAnnotations.Schema;

namespace E.Stadium.Infrastructure.Postgres.Stadiums;

[Table("stadiums")]
public class StadiumTable : BasePostgresTable
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("total_fields")]
    public int TotalFields { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("lat")]
    public decimal? Lat { get; set; }

    [Column("lon")]
    public decimal? Lon { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    public StadiumTable(
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

    public IEnumerable<FieldTable> Fields { get; set; } = new List<FieldTable>();
    public IEnumerable<StadiumMediaTable> StadiumMedias { get; set; } = new List<StadiumMediaTable>();
    public UserTable? User { get; set; }
}
