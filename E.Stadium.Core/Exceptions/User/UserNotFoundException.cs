using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class UserNotFoundException : BaseException
{
    public override string Code => "user_not_found";

    public UserNotFoundException(string userId) : base($"User with id {userId} not found") { }
    public UserNotFoundException(string userId, int statusCode) : base($"User with id {userId} not found", statusCode) { }

    public UserNotFoundException()
    {
    }

    public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
