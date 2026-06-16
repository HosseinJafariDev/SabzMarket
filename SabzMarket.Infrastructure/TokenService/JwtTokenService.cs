using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Exceptions;
using SabzMarket.Infrastructure.Configuration.JwtToken;

namespace SabzMarket.Infrastructure.TokenService;

public class JwtTokenService : ITokenService
{
    private readonly JwtConfiguration _configuration;

    public JwtTokenService(IOptions<JwtConfiguration> configuration)
    {
        _configuration = configuration.Value;
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Email, user.Email!),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.SecretKey!));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            issuer: _configuration.Issuer,
            audience: _configuration.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration.ExpirationInMinutes!)),
            signingCredentials: signingCredentials);

        var a = new JwtSecurityTokenHandler().WriteToken(token);
        return a;
    }
}