namespace E.Stadium.Abstraction.Exceptions;

public abstract class BaseException : Exception
{
    public abstract string Code { get; }

    public int StatusCode { get; } = 400;


    public object AdditionalData { get; set; } = new object();


    protected BaseException(string message)
        : base(message)
    {
    }

    protected BaseException(string message, int statusCode, object additionalData)
        : this(message, additionalData)
    {
        StatusCode = statusCode;
    }

    protected BaseException(string message, int statusCode)
        : this(message, statusCode, new object())
    {
    }

    public BaseException(string message, object additionalData)
        : this(message)
    {
        AdditionalData = additionalData;
    }

    public BaseException()
    {
    }

    public BaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
