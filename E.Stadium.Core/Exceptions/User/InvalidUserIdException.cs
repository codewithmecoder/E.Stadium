using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class InvalidUserIdException : BaseException
{
    public override string Code => "invalid_userid";

    public InvalidUserIdException(string userId) : base($"Invalid user id {userId}") { }

    public InvalidUserIdException()
    {
    }

    public InvalidUserIdException(string message, Exception innerException) : base(message, innerException)
    {
    }
}