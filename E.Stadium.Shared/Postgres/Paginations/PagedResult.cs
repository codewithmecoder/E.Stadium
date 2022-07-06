using System.Text.Json.Serialization;

namespace E.Stadium.Shared.Postgres.Paginations;

public class PagedResult : PagedResultBase
{
    protected PagedResult()
    {
    }

    protected PagedResult(int? currentPage, int resultsPerPage, int totalPages, long totalResults, string? lastPage)
        : base(currentPage, resultsPerPage, totalPages, totalResults, lastPage)
    {
    }

    public static PagedResult<T> Create<T>(IEnumerable<T> items, int resultsPerPage, int totalPages, long totalResults, int? currentPage = null, string? lastPage = null)
    {
        return new PagedResult<T>(items, currentPage, resultsPerPage, totalPages, totalResults, lastPage);
    }

    public static PagedResult<T> From<T>(PagedResultBase result, IEnumerable<T> items)
    {
        return new PagedResult<T>(items, result?.CurrentPage, result?.ResultsPerPage ?? 0, result?.TotalPages ?? 0, result?.TotalResults ?? 0, result?.LastPage);
    }

    public static Task<PagedResult<T>> FromAsync<T>(PagedResultBase result, IEnumerable<T> items)
    {
        IEnumerable<T> items2 = items;
        PagedResultBase result2 = result;
        return Task.Run(() => new PagedResult<T>(items2, result2?.CurrentPage, result2?.ResultsPerPage ?? 0, result2?.TotalPages ?? 0, result2?.TotalResults ?? 0, result2?.LastPage));
    }

    public static PagedResult<T> Empty<T>()
    {
        return new PagedResult<T>();
    }
}
public class PagedResult<T> : PagedResult
{
    public IEnumerable<T> Items { get; private set; }

    public bool IsEmpty
    {
        get
        {
            if (Items != null)
            {
                return !Items.Any();
            }

            return true;
        }
    }

    public bool IsNotEmpty => !IsEmpty;

    public PagedResult()
    {
        Items = Enumerable.Empty<T>();
    }

    [JsonConstructor]
    public PagedResult(IEnumerable<T> items, int? currentPage, int resultsPerPage, int totalPages, long totalResults, string? lastPage)
        : base(currentPage, resultsPerPage, totalPages, totalResults, lastPage)
    {
        Items = items;
    }

    public void Insert(int index, T t)
    {
        List<T> list = new(Items);
        list.Insert(index, t);
        Items = list;
        SetResultPerPage(ResultsPerPage + 1);
    }

    public PagedResult<U> Map<U>(Func<T, U> map)
    {
        return From(this, Items.Select(map));
    }

    public Task<PagedResult<U>> MapAsync<U>(Func<T, Task<U>> map)
    {
        return FromAsync(this, from x in Items.Select(map)
                               select x.Result);
    }
}
