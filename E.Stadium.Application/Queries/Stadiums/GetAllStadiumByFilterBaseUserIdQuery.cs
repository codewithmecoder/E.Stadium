using E.Stadium.Abstraction.Queries;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Application.Queries.Stadiums;

public class GetAllStadiumByFilterBaseUserIdQuery : IQuery<PagedResult<ResponseStadiumDto>>
{
    public string Filter { get; set; }
    public Guid UserId { get; set; }
    public int Page { get; set; }
    public int Result { get; set; }

    public GetAllStadiumByFilterBaseUserIdQuery(
        string filter,
        Guid userId,
        int page,
        int result)
    {
        Filter = filter;
        UserId = userId;
        Page = page;
        Result = result;
    }
}
