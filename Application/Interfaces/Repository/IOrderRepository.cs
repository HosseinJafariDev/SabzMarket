using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Orders;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<Order, long>
    {
    }
}