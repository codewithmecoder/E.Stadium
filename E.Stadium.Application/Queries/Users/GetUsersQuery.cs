using E.Stadium.Abstraction.Queries;
using E.Stadium.Core.Dto.Users;
using E.Stadium.Shared.Postgres.Paginations;

namespace E.Stadium.Application.Queries.Users
{
    public class GetUsersQuery : IQuery<PagedResult<UserDto>>
    {
        public bool IsActive { get; set; }
        public int Page { get; set; }
        public int Result { get; set; }

        public GetUsersQuery(
            bool isActive,
            int page,
            int result)
        {
            IsActive = isActive;
            Page = page;
            Result = result;
        }
    }
}
