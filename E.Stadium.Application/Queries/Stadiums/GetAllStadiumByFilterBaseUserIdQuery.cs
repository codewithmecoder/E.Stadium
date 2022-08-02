using E.Stadium.Abstraction.Queries;
using E.Stadium.Core.Dto.Base;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Application.Queries.Stadiums;

public class GetAllStadiumByFilterBaseUserIdQuery : BasePaginateDto, IQuery<PagedResult<ResponseStadiumDto>>
{
    public string Filter { get; set; }
    public Guid UserId { get; set; }

    public GetAllStadiumByFilterBaseUserIdQuery(
        string filter,
        Guid userId,
        int page,
        int result)
    {
        Filter = filter;
        UserId = userId;
        Page = page;
        Results = result;
    }
}
