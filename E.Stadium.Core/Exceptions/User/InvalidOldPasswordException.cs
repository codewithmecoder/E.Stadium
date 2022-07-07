using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class InvalidOldPasswordException : BaseException
{
    public override string Code => "invalid_old_password";

    public InvalidOldPasswordException() : base("Invalid old password") { }

    public InvalidOldPasswordException(string message) : base(message)
    {
    }

    public InvalidOldPasswordException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}
