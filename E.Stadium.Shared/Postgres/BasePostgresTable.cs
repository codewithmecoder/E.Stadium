using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E.Stadium.Shared.Postgres;

public class BasePostgresTable
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
}
