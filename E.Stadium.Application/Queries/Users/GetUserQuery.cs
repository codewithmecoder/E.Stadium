using E.Stadium.Abstraction.Queries;
using E.Stadium.Core.Dto.Users;

namespace E.Stadium.Application.Queries.Users;

public class GetUserQuery : IQuery<UserDto>
{
    public Guid UserId { get; set; }

    public GetUserQuery(Guid userId)
    {
        UserId = userId;
    }
}
