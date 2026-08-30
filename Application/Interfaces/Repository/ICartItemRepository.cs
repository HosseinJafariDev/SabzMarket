using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.CartItems;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ICartItemRepository:IRepository<CartItem,int>
    {
    }
}
