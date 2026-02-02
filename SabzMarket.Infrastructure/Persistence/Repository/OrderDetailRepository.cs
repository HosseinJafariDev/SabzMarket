using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.DAL.Entities;
using SabzMarket.Infrastructure.Persistence;
using SabzMarket.Share.Enums;
using SabzMarket.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly SabzMarketDbContext _context;
        public OrderDetailRepository(SabzMarketDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> HasPendingOrdersForProductAsync(long productId)
        {
            try
            {
                var result = await _context
                    .OrderDetails
                    .AsNoTracking()
                    .Where(p =>
                    p.ProductId == productId &&
                    p.Status == OrderStatus.Pending.ToString())
                    .AnyAsync();
                return OperationResult.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }

        }

        public async Task<OperationResult> InsertAsync(FullCartItemDTO fullCartItemDTOs, long orderId)
        {
            try
            {
                var orderDetails =  new OrderDetail
                {
                    OrderId = orderId,
                    ProductId = fullCartItemDTOs.ProductId,
                    Number = fullCartItemDTOs.Quantity,
                    Price = fullCartItemDTOs.ProductPrice,
                    Status = OrderStatus.Pending.ToString()
                };
                _context.OrderDetails.Add(orderDetails);
                await _context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }

        }

        public async Task<OperationResult> SetOrderDetailStatusToRejectedAsync(long orderDetaileId)
        {
            try
            {
                var orderDetail = new OrderDetail { Id = orderDetaileId };
                _context.Attach(orderDetail);
                orderDetail.Status = OrderStatus.Rejected.ToString();
                var entry = _context.Entry(orderDetail);
                entry.Property(x => x.Status).IsModified = true;
                await _context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> SetOrderDetailStatusToSentAsync(long orderDetaileId)
        {
            try
            {
                var orderDetail = new OrderDetail { Id = orderDetaileId };
                _context.Attach(orderDetail);
                orderDetail.Status = OrderStatus.Sent.ToString();
                var entry = _context.Entry(orderDetail);
                entry.Property(x => x.Status).IsModified = true;
                await _context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }
    }
}
