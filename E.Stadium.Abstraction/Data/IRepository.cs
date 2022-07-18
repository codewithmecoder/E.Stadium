namespace E.Stadium.Abstraction.Data;

public interface IRepository<in TEntity> where TEntity : IEntity
{
}
