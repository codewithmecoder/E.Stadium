using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Core.Exceptions.Stadiums;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres;
using E.Stadium.Infrastructure.Postgres.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;
using Microsoft.EntityFrameworkCore;

namespace E.Stadium.Infrastructure.Repositories;

public class StadiumRepository : IStadiumRepository
{
    private readonly IPostgresRepository<StadiumTable> _repository;

    public StadiumRepository(IPostgresRepository<StadiumTable> repository)
    {
        _repository = repository;
    }
    public Task CreateAsync(StadiumEntity stadium)
    => _repository.AddAsync(stadium.AsTable());

    public async Task DeleteByIdAsync(Guid id, Guid ownerId)
    {
        var data = await GetByIdAsync(id, ownerId);
        data.IsActive = false;
        await _repository.UpdateAsync(data.AsTable());
    }

    public Task<PagedResult<StadiumEntity>> GetByFilterAsync(string filter, int page, int result)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<StadiumEntity>> GetByFilterAsync(string filter, Guid owerId, int page, int result)
    {
        throw new NotImplementedException();
    }

    public async Task<StadiumEntity> GetByIdAsync(Guid id, Guid ownerId)
    {
        var data = await _repository.Context.Stadiums
            .Include(i => i.StadiumMedias)
            .Include(i => i.Fields)
            .ThenInclude(i => i.FieldMedias)
            .FirstOrDefaultAsync(i => i.Id == id && i.UserId == ownerId);
        if (data is null) throw new StadiumNotFoundException(id);
        return data.AsEntity();
    }

    public Task UpdateAsync(StadiumEntity stadium)
    {
        throw new NotImplementedException();
    }
}
