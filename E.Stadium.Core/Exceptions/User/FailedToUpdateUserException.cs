using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class FailedToUpdateUserException : BaseException
{
    public override string Code => "unable_update_user";

    public FailedToUpdateUserException(string message) : base(message)
    {
    }

    public FailedToUpdateUserException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public FailedToUpdateUserException()
    {
    }
}
