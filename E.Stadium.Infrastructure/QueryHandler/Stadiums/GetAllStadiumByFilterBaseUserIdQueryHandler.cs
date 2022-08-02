using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Queries.Stadiums;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Repositories;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Infrastructure.QueryHandler.Stadiums;

public class GetAllStadiumByFilterBaseUserIdQueryHandler : IQueryHandler<GetAllStadiumByFilterBaseUserIdQuery, PagedResult<ResponseStadiumDto>>
{
    private readonly IStadiumRepository _stadiumRepository;

    public GetAllStadiumByFilterBaseUserIdQueryHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }
    public async Task<PagedResult<ResponseStadiumDto>> HandleAsync(GetAllStadiumByFilterBaseUserIdQuery query)
    {
        return await _stadiumRepository.GetByFilterAsync(query.Filter, query.UserId, query.Page, query.Result);
    }
}
