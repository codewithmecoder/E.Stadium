using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class ExistedPhoneException : BaseException
{
    public override string Code => "existed_phone";

    public ExistedPhoneException(string phone) : base($"Duplicate phone {phone}")
    {

    }

    public ExistedPhoneException()
    {
    }

    public ExistedPhoneException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}
