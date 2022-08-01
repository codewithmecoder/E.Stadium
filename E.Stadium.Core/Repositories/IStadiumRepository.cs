using E.Stadium.Abstraction.Data;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Core.Repositories;

public interface IStadiumRepository : IRepository<StadiumEntity>
{
    Task CreateAsync(StadiumEntity stadium);
    Task UpdateAsync(StadiumEntity stadium);
    Task<StadiumEntity> GetByIdAsync(Guid id, Guid ownerId);
    Task DeleteByIdAsync(Guid id, Guid ownerId);
    Task<PagedResult<StadiumEntity>> GetByFilterAsync(string filter, int page, int result);
    Task<PagedResult<StadiumEntity>> GetByFilterAsync(string filter, Guid owerId, int page, int result);
}
