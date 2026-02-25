using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using SabzMarket.Infrastructure.Entities;
using SabzMarket.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SabzMarketDbContext _context;
        public OrderRepository(SabzMarketDbContext context)
        {
            _context = context;
        }
        public async Task<long> InsertAsync(Order order)
        {
            var orderTable = new OrderTable
            {
                FarmerId = order.FarmerId,
                OrderDate = order.OrderDate,
                SellerId = order.SellerId,
            };

            _context.Orders.AddRange(orderTable);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<bool> CheckOrderAsync(long farmerId, long SellerId)
        {
            var result = await _context
           .Orders
           .AsNoTracking()
           .Where(x => x.FarmerId == farmerId && x.SellerId == SellerId)
           .AnyAsync();
            return result;
        }
        public async Task<long> FindOrderByFarmerAndSellerAsync(long farmerId, long SellerId)
        {
            var order = await _context
          .Orders
          .AsNoTracking()
          .Where(x => x.FarmerId == farmerId && x.SellerId == SellerId).SingleAsync();

            return order.Id;
        }
    }
}
