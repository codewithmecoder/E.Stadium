namespace E.Stadium.Abstraction.Vonage;

public class VonageOptions
{
    public string ApiKey { get; set; } = string.Empty;
    public string ApiSecret { get; set; } = string.Empty;
    public int CodeLength { get; set; } = 6;
    public string SenderId { get; set; } = string.Empty;
}
