using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Queries.Users;
using E.Stadium.Core.Dto.Users;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres.User;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Infrastructure.QueryHandler.Users;

public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, PagedResult<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<PagedResult<UserDto>> HandleAsync(GetUsersQuery query)
    {
        var data = await _userRepository.GetUsersAsync(query.IsActive, query.Page, query.Result);
        return data.Map(i => i.AsUserDto());
    }
}
