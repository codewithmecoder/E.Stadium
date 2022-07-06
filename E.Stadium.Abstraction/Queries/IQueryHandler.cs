namespace E.Stadium.Abstraction.Queries;

public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery
{
    Task<TResult> HandleAsync(TQuery query);
}
