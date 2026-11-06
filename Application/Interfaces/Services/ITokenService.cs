using SabzMarket.Domain.Entities.User;

namespace SabzMarket.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}