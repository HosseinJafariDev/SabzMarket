using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Chat;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IChatRepository : IRepository<Chat, long>
    {
    }
}