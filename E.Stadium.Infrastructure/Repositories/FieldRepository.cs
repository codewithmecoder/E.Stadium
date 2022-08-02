using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Core.Exceptions.Fields;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres;
using E.Stadium.Infrastructure.Postgres.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;
using Microsoft.EntityFrameworkCore;

namespace E.Stadium.Infrastructure.Repositories;

public class FieldRepository : IFieldRepository
{
    private readonly IPostgresRepository<FieldTable> _repository;

    public FieldRepository(IPostgresRepository<FieldTable> repository)
    {
        _repository = repository;
    }
    public Task CreateAsync(FieldEntity field)
    => _repository.AddAsync(field.AsTable());

    public async Task DeleteByIdAsync(Guid id)
    {
        var field = await FindByIdAsync(id);
        if (field == null) throw new FieldNotFoundException(id);
        field.IsActive = false;
        await _repository.UpdateAsync(field.AsTable());
    }

    public async Task<FieldEntity> FindByIdAsync(Guid id)
    {
        var data = await _repository.FirstOrDefaultAsync(i => i.Id == id);
        return data.AsEntity();
    }

    public async Task<PagedResult<ResponseFieldDto>> GetFieldsAsync(Guid staduimId, int page, int result)
    {
        var data = await _repository.Context.Fields.Include(i => i.FieldMedias).Where(i => i.StadiumId == staduimId && i.IsActive)
            .OrderByDescending(i => i.CreatedAt)
            .AsQueryable()
            .PaginateAsync(new PagedQueryBase { Page = page, Limit = result });
        var res = data.Map(i => i.AsEntity().AsDto());
        return res;
    }

    public Task UpdateAsync(FieldEntity field)
    => _repository.UpdateAsync(field.AsTable());
}
