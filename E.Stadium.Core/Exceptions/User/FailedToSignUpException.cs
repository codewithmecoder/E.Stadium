using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class FailedToSignUpException : BaseException
{
    public override string Code => "signup_failed";

    public FailedToSignUpException(string message) : base(message)
    {
    }

    public FailedToSignUpException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public FailedToSignUpException()
    {
    }
}
