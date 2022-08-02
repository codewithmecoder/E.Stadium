using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Queries.Fields;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Repositories;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Infrastructure.QueryHandler.Fields;

public class GetFieldBaseOnStadiumQueryHandler : IQueryHandler<GetFieldBaseOnStadiumQuery, PagedResult<ResponseFieldDto>>
{
    private readonly IFieldRepository _fieldRepository;

    public GetFieldBaseOnStadiumQueryHandler(IFieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
    }

    public async Task<PagedResult<ResponseFieldDto>> HandleAsync(GetFieldBaseOnStadiumQuery query)
        => await _fieldRepository.GetFieldsAsync(query.StadiumId, query.Page, query.Results);
}
