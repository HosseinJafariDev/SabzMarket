using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.UseCases.Orders.GetOrders;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.QueryServices
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly SabzMarketDbContext _context;
        public OrderQueryService(SabzMarketDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetOrdersForSellerOutputDTO>> SelectNonPendingOrdersForSellerAsync(long sellerId, string search, CancellationToken token)
        {
            var query = _context.Orders
                  .AsNoTracking()
                  .Include(x => x.OrderDetails)
                  .ThenInclude(x => x.Product)
                  .Include(x => x.Farmer)
                  .Where(u => u.SellerId == sellerId);

            var queryDetails = query
                .SelectMany(o => o.OrderDetails, (order, detail) => new { order, detail })
                .Where(x => x.detail.Status != OrderStatus.Pending.ToString());

            if (!string.IsNullOrEmpty(search))
            {
                queryDetails = queryDetails.Where(o => o.order.Farmer!.User!.FirstName!.Contains(search)
                                      || o.order.Farmer!.User!.LastName!.Contains(search)
                                        || o.detail.Product!.ProductName!.Contains(search));
            }


            var result = await queryDetails.Select(o => new GetOrdersForSellerOutputDTO
            {
                OrderId = o.order.Id,
                OrderDetailId = o.detail.Id,
                Status = o.detail.Status,

                ProductId = o.detail.Product!.Id,
                Number = o.detail.Number,
                ImageProduct = o.detail.Product.ImageProduct,
                ProductName = o.detail.Product.ProductName,

                FarmerId = o.order.Farmer!.Id,
                Address = o.order.Farmer.Address,
                FarmerProfileImage = o.order.Farmer.ProfileImage,
                Phone = o.order.Farmer.User!.Phone,
                FirstName = o.order.Farmer.User!.FirstName,
                CodePosti = o.order.Farmer.CodePosti,
                LastName = o.order.Farmer.User!.LastName
            }).ToListAsync(token);

            return result;
        }

        public async Task<List<GetOrdersForSellerOutputDTO>> SelectPendingOrdersForSellerAsync(long sellerId, string search, CancellationToken token)
        {
            var query = _context.Orders
                  .AsNoTracking()
                  .Include(x => x.OrderDetails)
                  .ThenInclude(x => x.Product)
                  .Include(x => x.Farmer)
                  .Where(u => u.SellerId == sellerId);

            var queryDetails = query
                .SelectMany(o => o.OrderDetails, (order, detail) => new { order, detail })
                .Where(x => x.detail.Status == OrderStatus.Pending.ToString());

            if (!string.IsNullOrEmpty(search))
            {
                queryDetails = queryDetails.Where(o => o.order.Farmer!.User!.FirstName!.Contains(search)
                                      || o.order.Farmer!.User!.LastName!.Contains(search)
                                        || o.detail.Product!.ProductName!.Contains(search));
            }


            var result = await queryDetails.Select(o => new GetOrdersForSellerOutputDTO
            {
                OrderId = o.order.Id,
                OrderDetailId = o.detail.Id,
                Status = o.detail.Status,
                ProductId = o.detail.Product!.Id,
                Number = o.detail.Number,
                ImageProduct = o.detail.Product.ImageProduct,
                ProductName = o.detail.Product.ProductName,
                FarmerId = o.order.Farmer!.Id,
                Address = o.order.Farmer.Address,
                FarmerProfileImage = o.order.Farmer.ProfileImage,
                Phone = o.order.Farmer.User!.Phone,
                FirstName = o.order.Farmer.User!.FirstName,
                CodePosti = o.order.Farmer.CodePosti,
                LastName = o.order.Farmer.User!.LastName
            }).ToListAsync(token);

            return result;
        }
    }
}
