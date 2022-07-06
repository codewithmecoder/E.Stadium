using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class LoginFailedException : BaseException
{
    public override string Code => "login_failed";

    public LoginFailedException() : base("Login failed with this credential") { }

    public LoginFailedException(string message) : base(message)
    {
    }

    public LoginFailedException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}
