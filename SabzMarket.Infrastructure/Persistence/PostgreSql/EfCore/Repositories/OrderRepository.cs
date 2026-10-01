using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Common.Dtos;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Domain.Enums;
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

    public async Task<PagedResult<Order>> GetOrderBySellerId(long id, string? search, int? price, int? number,
        int pageNumber, int pageSize,
        CancellationToken token, OrderStatus status = 0)
    {
        var query = Context.Orders.AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(x =>
                x.Farmer!.User!.FirstName.Contains(search) ||
                search.Contains(x.Farmer.User.LastName) ||
                x.OrderDetails.Any(x => x.Product!.Name.Contains(search)));

        if (price is not null)
            query = query.Where(x => x.OrderDetails.Any(x => x.Price == price));

        if (number is not null)
            query = query.Where(x => x.OrderDetails.Any(x => x.Number == number));

        query = query.Where(x => x.OrderDetails.Any(x => x.Status == status));

        query.Include(x => x.OrderDetails).ThenInclude(x => x.Product).Include(x => x.Farmer).ThenInclude(x => x.User);

        var count = await query.CountAsync(token);

        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        var order = await query.AsNoTracking().ToListAsync(token);

        return new PagedResult<Order>(order, count);
    }
}