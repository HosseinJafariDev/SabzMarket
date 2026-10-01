using SabzMarket.Application.Common.Dtos;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Domain.Enums;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<Order, long>
    {
        Task<Order?> GetOrderWithDetilsByProductId(long id, CancellationToken token);

        Task<PagedResult<Order>> GetOrderBySellerId(long id, string? search, int? price, int? number, int pageNumber,
            int pageSize,
            CancellationToken token, OrderStatus status = 0);
    }
}