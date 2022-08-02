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
        var data = await GetOnlyStadiumByIdAsync(id, ownerId);
        data.IsActive = false;
        await _repository.UpdateAsync(data.AsTable());
    }

    public  async Task<PagedResult<ResponseStadiumDto>> GetByFilterAsync(string filter, int page, int result)
    {
        var pages = await _repository.Context.Stadiums
            .Include(i => i.StadiumMedias)
            .Include(i => i.Fields)
            .ThenInclude(i => i.FieldMedias)
            .Where(i => (i.IsActive ?? false) == true)
            .OrderByDescending(i => i.CreatedAt)
            .AsQueryable()
            .PaginateAsync(new PagedQueryBase { Page = page, Limit = result });
        var res = pages.Map(x =>
        {
            return x?.AsEntity().AsDto();
        });
        return res!;
    }

    public async Task<PagedResult<ResponseStadiumDto>> GetByFilterAsync(string filter, Guid ownerId, int page, int result)
    {
        var pages = await _repository.Context.Stadiums
            .Include(i => i.StadiumMedias)
            .Include(i => i.Fields)
            .ThenInclude(i => i.FieldMedias)
            .Where(i => i.UserId == ownerId && (i.IsActive ?? false) == true)
            .OrderByDescending(i => i.CreatedAt)
            .AsQueryable()
            .PaginateAsync(new PagedQueryBase { Page = page, Limit = result });
        var res = pages.Map(x =>
        {
            return x?.AsEntity().AsDto();
        });
        return res!;
    }

    public async Task<StadiumEntity> GetByIdAsync(Guid id, Guid ownerId)
    {
        var data = await _repository.Context.Stadiums
            .Include(i => i.StadiumMedias)
            .Include(i => i.Fields)
            .ThenInclude(i => i.FieldMedias)
            .FirstOrDefaultAsync(i => i.Id == id && i.UserId == ownerId && (i.IsActive ?? false) == true);
        if (data is null) throw new StadiumNotFoundException(id);
        return data.AsEntity();
    }

    public Task UpdateAsync(StadiumEntity stadium)
    {
        return _repository.UpdateAsync(stadium.AsTable());
    }

    public async Task<StadiumEntity> GetOnlyStadiumByIdAsync(Guid id, Guid ownerId)
    {
        var data = await _repository.FirstOrDefaultAsync(i => i.Id == id && i.UserId == ownerId && (i.IsActive ?? false) == true);
        if (data is null) throw new StadiumNotFoundException(id);
        return data.AsEntity();
    }
}
