using SabzMarket.Domain.Entities.Users;

namespace SabzMarket.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}