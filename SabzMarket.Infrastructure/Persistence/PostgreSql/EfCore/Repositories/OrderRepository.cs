using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories.Base;

namespace SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories;

public class OrderRepository(SabzMarketDbContext context) : RepositoryBase<Order, long>(context), IOrderRepository
{
    public async Task<Order?> GetOrderWithDetilsByProductId(long id, CancellationToken token)
    {
        var order = await Context.Orders.Include(x => x.OrderDetails).FirstOrDefaultAsync(token);

        return order;
    }
}