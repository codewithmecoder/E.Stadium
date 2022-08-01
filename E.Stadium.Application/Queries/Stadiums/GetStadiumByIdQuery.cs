using E.Stadium.Abstraction.Queries;
using E.Stadium.Core.Dto.Stadiums;
using E.Stadium.Core.Entities.Stadiums;

namespace E.Stadium.Application.Queries.Stadiums;

public class GetStadiumByIdQuery : IQuery<ResponseStadiumDto>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public GetStadiumByIdQuery(Guid id , Guid userId)
    {
        Id = id;
        UserId = userId;
    }
}
