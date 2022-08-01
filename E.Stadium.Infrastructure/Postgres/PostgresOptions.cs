namespace E.Stadium.Infrastructure.Postgres;

public class PostgresOptions
{
    public string ConnectionString { get; set; } = null!;
    public string ConnectionStringDev { get; set; } = null!;
}
