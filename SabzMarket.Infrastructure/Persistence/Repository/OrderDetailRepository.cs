using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Infrastructure.Entities;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly SabzMarketDbContext _context;
        public OrderDetailRepository(SabzMarketDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasPendingOrdersForProductAsync(long productId)
        {
            var result = await _context
                .OrderDetails
                .AsNoTracking()
                .Where(p =>
                p.ProductId == productId &&
                p.Status == OrderStatus.Pending.ToString())
                .AnyAsync();
            return result;
        }

        public async Task InsertAsync(OrderDetail orderDetail)
        {
            var orderDetails = new OrderDetailTable
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Number = orderDetail.Number,
                Price = orderDetail.Price,
                Status = OrderStatus.Pending.ToString()
            };
            _context.OrderDetails.Add(orderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task SetOrderDetailStatusToRejectedAsync(long orderDetaileId)
        {
            var orderDetail = new OrderDetailTable { Id = orderDetaileId };
            _context.Attach(orderDetail);
            orderDetail.Status = OrderStatus.Rejected.ToString();
            var entry = _context.Entry(orderDetail);
            entry.Property(x => x.Status).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task SetOrderDetailStatusToSentAsync(long orderDetaileId)
        {
                var orderDetail = new OrderDetailTable { Id = orderDetaileId };
                _context.Attach(orderDetail);
                orderDetail.Status = OrderStatus.Sent.ToString();
                var entry = _context.Entry(orderDetail);
                entry.Property(x => x.Status).IsModified = true;
                await _context.SaveChangesAsync();
        }

    }
}