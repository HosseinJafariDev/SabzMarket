using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Chats;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IChatRepository : IRepository<Chat, long>
    {
    }
}