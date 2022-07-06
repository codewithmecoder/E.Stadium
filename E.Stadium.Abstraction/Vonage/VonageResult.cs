namespace E.Stadium.Abstraction.Vonage;

public class VonageResult
{
    public string StatusCode { get; set; } = string.Empty;
    public string ErrorMsg { get; set; } = string.Empty;
    public string RequestId { get; set; } = string.Empty;
}
