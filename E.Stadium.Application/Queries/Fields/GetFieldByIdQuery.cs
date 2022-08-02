using E.Stadium.Abstraction.Queries;
using E.Stadium.Core.Dto.Stadiums;

namespace E.Stadium.Application.Queries.Fields;

public class GetFieldByIdQuery : IQuery<ResponseFieldDto>
{
    public Guid Id { get; set; }

    public GetFieldByIdQuery(Guid id)
    {
        Id = id;
    }
}
