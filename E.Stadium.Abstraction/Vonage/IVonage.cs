namespace E.Stadium.Abstraction.Vonage;

public interface IVonage
{
    Task<VonageResult> RequestAsync(string phone, string message = "Your verify");

    Task<VonageResult> VerifyAsync(string requestId, string code);
}
