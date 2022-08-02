using E.Stadium.Abstraction.Queries;
using E.Stadium.Core.Dto.Base;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Application.Queries.Fields;

public class GetFieldBaseOnStadiumQuery : BasePaginateDto , IQuery<PagedResult<ResponseFieldDto>>
{
    public Guid StadiumId { get; set; }

    public GetFieldBaseOnStadiumQuery(Guid stadiumId)
    {
        StadiumId = stadiumId;
    }
}
