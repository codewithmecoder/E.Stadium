namespace E.Stadium.Abstraction.Jwt;

public class JwtOptions
{
    public string Site { get; set; } = string.Empty;
    public string SigningKey { get; set; } = string.Empty;
    public int ExpiryInMinutes { get; set; }
    public string? Audience { get; set; }
}
