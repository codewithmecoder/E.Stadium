using E.Stadium.Abstraction.Queries;
using E.Stadium.Application.Queries.Users;
using E.Stadium.Core.Dto.Users;
using E.Stadium.Core.Exceptions.User;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres.User;

namespace E.Stadium.Infrastructure.QueryHandler.Users;

public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> HandleAsync(GetUserQuery query)
    {
        var user = await _userRepository.GetAsync(query.UserId);
        if (user is null)
            throw new UserNotFoundException();

        return user.AsUserDto();
    }
}
