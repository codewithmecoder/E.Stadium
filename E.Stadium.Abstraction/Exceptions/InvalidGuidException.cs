namespace E.Stadium.Abstraction.Exceptions;

public class InvalidGuidException : BaseException
{
    public override string Code => "invalid_id";

    public InvalidGuidException(string id)
        : base("Invalid id " + id)
    {
    }

    public InvalidGuidException()
    {
    }

    public InvalidGuidException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
