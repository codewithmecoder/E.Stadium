using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E.Stadium.Shared.Postgres.Paginations;

public class PagedQueryBase : IPagedQuery
{
    public int Page { get; set; } = 1;


    public int Limit { get; set; } = 10;


    [BindNever]
    public int PageNumber => (Page - 1) * Limit;

    public PagedQueryBase()
    {
    }

    public PagedQueryBase(int page, int limit)
    {
        Page = page;
        Limit = limit;
    }

    public int TotalPages(long total)
    {
        return (int)Math.Ceiling((decimal)total / (decimal)Limit);
    }
}
