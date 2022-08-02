using E.Stadium.Abstraction.Data;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Entities.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Core.Repositories;

public interface IFieldRepository : IRepository<FieldEntity>
{
    Task CreateAsync(FieldEntity field);
    Task UpdateAsync(FieldEntity field);
    Task DeleteByIdAsync(Guid id);
    Task<FieldEntity> FindByIdAsync(Guid id);
    Task<PagedResult<ResponseFieldDto>> GetFieldsAsync(Guid staduimId, int page, int result);
}
