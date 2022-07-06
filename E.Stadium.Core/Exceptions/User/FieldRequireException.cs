using E.Stadium.Abstraction.Exceptions;

namespace E.Stadium.Core.Exceptions.User;

public class FieldRequireException : BaseException
{
    public override string Code => "field_require";

    public FieldRequireException(string fieldName) : base($"Field {fieldName} require") { }

    public FieldRequireException()
    {
    }

    public FieldRequireException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}
