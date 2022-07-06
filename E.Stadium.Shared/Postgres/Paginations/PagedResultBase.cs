namespace E.Stadium.Shared.Postgres.Paginations;

public abstract class PagedResultBase
{
    public int? CurrentPage { get; }

    public string? LastPage { get; private set; }

    public int ResultsPerPage { get; private set; }

    public int TotalPages { get; }

    public long TotalResults { get; }

    protected void SetResultPerPage(int resultPerPage)
    {
        ResultsPerPage = resultPerPage;
    }

    public void SetLastPage(string? lastPage)
    {
        LastPage = lastPage;
    }

    protected PagedResultBase()
    {
    }

    protected PagedResultBase(int? currentPage, int resultsPerPage, int totalPages, long totalResults, string? lastPage)
    {
        CurrentPage = currentPage > totalPages ? new int?(totalPages) : currentPage;
        ResultsPerPage = resultsPerPage;
        TotalPages = totalPages;
        TotalResults = totalResults;
        LastPage = lastPage;
    }
}
