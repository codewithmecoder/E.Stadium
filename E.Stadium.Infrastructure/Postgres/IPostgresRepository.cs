using System.Linq.Expressions;
using E.Stadium.Shared.Postgres;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Infrastructure.Postgres;

public interface IPostgresRepository<T> where T : BasePostgresTable
{
    PostgresDbContext Context { get; }

    Task<T> FirstOrDefaultAsync(Guid id);

    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);

    Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    Task<PagedResult<T>> BrowseAsync<TQuery>(Expression<Func<T, bool>> predicate,
        TQuery query) where TQuery : IPagedQuery;

    Task<PagedResult<T>> BrowseAsync<TQuery>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order,
        TQuery query) where TQuery : IPagedQuery;

    Task<PagedResult<T>> BrowseDescAsync<TQuery>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> order,
        TQuery query) where TQuery : IPagedQuery;

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task<int> DeleteAsync(Guid id);

    Task<int> DeleteAsync(T entity);

    Task<int> DeleteAsync(Expression<Func<T, bool>> predicate);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}
