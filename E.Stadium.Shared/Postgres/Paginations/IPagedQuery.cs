namespace E.Stadium.Shared.Postgres.Paginations;

public interface IPagedQuery
{
    int Page { get; }
    int Limit { get; }
}
