using E.Stadium.Abstraction.Queries;
using E.Stadium.Core.Dto.Base;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Application.Queries.Stadiums;

public class GetAllStadiumByFilterQuery : BasePaginateDto, IQuery<PagedResult<ResponseStadiumDto>>
{
    public string? Filter { get; set; }

    public GetAllStadiumByFilterQuery(
        string? filter,
        int page,
        int result)
    {
        Filter = filter;
        Page = page;
        Results = result;
    }
}
