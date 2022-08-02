using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Queries.Stadiums;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Repositories;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Infrastructure.QueryHandler.Stadiums;

public class GetAllStadiumByFilterQueryHandler : IQueryHandler<GetAllStadiumByFilterQuery, PagedResult<ResponseStadiumDto>>
{
    private readonly IStadiumRepository _stadiumRepository;

    public GetAllStadiumByFilterQueryHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }
    public async Task<PagedResult<ResponseStadiumDto>> HandleAsync(GetAllStadiumByFilterQuery query)
    {
        return await _stadiumRepository.GetByFilterAsync(query.Filter ?? string.Empty, query.Page, query.Results);
    }
}
