using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

class FailedToCreateTokenException : BaseException
{
    public override string Code => "failed_generate_token";

    public FailedToCreateTokenException(string message) : base(message)
    {
    }

    public FailedToCreateTokenException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public FailedToCreateTokenException() : base("Failed to generate token")
    {
    }
}
