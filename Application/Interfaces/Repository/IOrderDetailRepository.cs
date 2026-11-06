using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Order;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail, long>
    {
    }
}