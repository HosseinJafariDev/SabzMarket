using System.Security.Claims;
using SabzMarket.Domain.Entities;

namespace SabzMarket.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);

    ClaimsPrincipal? ValidateToken(string token);
}