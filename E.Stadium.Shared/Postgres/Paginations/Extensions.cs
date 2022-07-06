using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E.Stadium.Shared.Postgres.Paginations;

public static class Pagination
{
    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, IPagedQuery query)
    {
        int page2;
        if (query != null)
        {
            int page = query.Page;
            page2 = page;
        }
        else
        {
            page2 = 1;
        }

        int resultsPerPage;
        if (query != null)
        {
            int limit = query.Limit;
            resultsPerPage = limit;
        }
        else
        {
            resultsPerPage = 0;
        }

        return await collection.PaginateAsync(page2, resultsPerPage);
    }

    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, int page = 1, int resultsPerPage = 10)
    {
        if (page <= 0)
        {
            page = 1;
        }

        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }

        if (!await collection.AnyAsync())
        {
            return PagedResult.Empty<T>();
        }

        int totalResults = await collection.CountAsync();
        return PagedResult.Create(totalPages: (int)Math.Ceiling(totalResults / (decimal)resultsPerPage), items: await collection.Limit(page, resultsPerPage).ToListAsync(), resultsPerPage: resultsPerPage, totalResults: totalResults, currentPage: page, lastPage: "");
    }

    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, Expression<Func<T, bool>> condition, int resultsPerPage = 10)
    {
        int page = 1;
        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }

        if (!await collection.AnyAsync())
        {
            return PagedResult.Empty<T>();
        }

        int totalResults = await collection.CountAsync();
        return PagedResult.Create(totalPages: (int)Math.Ceiling((decimal)totalResults / resultsPerPage), items: await collection.Where(condition).Limit(page,
            resultsPerPage).ToListAsync(), resultsPerPage: resultsPerPage, totalResults: totalResults, currentPage: page, lastPage: "");
    }

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection, IPagedQuery query) => collection.Limit(query?.Page ?? 1, query?.Limit ?? 0);

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection, int page = 1, int resultsPerPage = 10)
    {
        if (page <= 0)
        {
            page = 1;
        }

        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }

        int count = (page - 1) * resultsPerPage;
        return collection.Skip(count).Take(resultsPerPage);
    }
}
