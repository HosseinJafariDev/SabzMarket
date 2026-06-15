namespace SabzMarket.Infrastructure.Configuration.JwtToken;

public class JwtConfiguration
{
    public string? SecretKey { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string? ExpirationInMinutes { get; set; }
}