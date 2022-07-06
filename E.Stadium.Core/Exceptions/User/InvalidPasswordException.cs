using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class InvalidPasswordException : BaseException
{
    public override string Code => "password_invalid_exception";

    public InvalidPasswordException(string message) : base(message)
    {
    }

    public InvalidPasswordException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidPasswordException()
    {
    }
}
