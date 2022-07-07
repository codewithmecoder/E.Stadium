using System.Linq.Expressions;
using E.Stadium.Shared.Postgres;
using E.Stadium.Shared.Postgres.Paginations;
using Microsoft.EntityFrameworkCore;

namespace E.Stadium.Infrastructure.Postgres;

public class PostgresRepository<TTable> : IPostgresRepository<TTable> where TTable : BasePostgresTable
{
    public PostgresDbContext Context { get; }

    public PostgresRepository(PostgresDbContext context)
    {
        Context = context;
    }

    public async Task<TTable> AddAsync(TTable entity)
    {
        Context.Set<TTable>().Add(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate, TQuery query) where TQuery : IPagedQuery
        => Context.Set<TTable>().AsQueryable().Where(predicate).AsNoTracking().PaginateAsync(query);

    public Task<PagedResult<TTable>> BrowseDescAsync<TQuery>(Expression<Func<TTable, bool>> predicate, Expression<Func<TTable, object>> order, TQuery query) where TQuery : IPagedQuery
        => Context.Set<TTable>().AsQueryable().Where(predicate).OrderByDescending(order).AsNoTracking().PaginateAsync(query);

    public Task<int> DeleteAsync(Guid id)
        => DeleteAsync(x => x.Id == id);

    public Task<int> DeleteAsync(TTable entity)
    {
        Context.Set<TTable>().Remove(entity);
        return Context.SaveChangesAsync();
    }

    public Task<int> DeleteAsync(Expression<Func<TTable, bool>> predicate)
    {
        var collection = Context.Set<TTable>().Where(predicate);
        Context.Set<TTable>().RemoveRange(collection);

        return Context.SaveChangesAsync();
    }

    public Task<bool> ExistsAsync(Expression<Func<TTable, bool>> predicate)
    {
        return Context.Set<TTable>().AnyAsync(predicate);
    }

    public async Task<IEnumerable<TTable>> WhereAsync(Expression<Func<TTable, bool>> predicate)
        => await Context.Set<TTable>().Where(predicate).AsNoTracking().ToListAsync();

    public Task<TTable> FirstOrDefaultAsync(Guid id) => Context.Set<TTable>().AsNoTracking().FirstOrDefaultAsync(i=> i.Id == id)!;

    public Task<TTable> FirstOrDefaultAsync(Expression<Func<TTable, bool>> predicate)
        => Context.Set<TTable>().Where(predicate).AsNoTracking().FirstOrDefaultAsync()!;

    public Task UpdateAsync(TTable entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.Set<TTable>().Update(entity);
        return Context.SaveChangesAsync();
    }

    public Task<int> CountAsync(Expression<Func<TTable, bool>> predicate)
     => Context.Set<TTable>().Where(predicate).CountAsync();

    public Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate, Expression<Func<TTable, object>> order, TQuery query) where TQuery : IPagedQuery
        => Context.Set<TTable>().AsQueryable().Where(predicate).OrderBy(order).AsNoTracking().PaginateAsync(query);
}
