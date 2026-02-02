using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.DAL.Entities;
using SabzMarket.Infrastructure.Persistence;
using SabzMarket.Share.Enums;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
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
        public async Task<OperationResult<List<OrderDTO>>> SelectPendingOrdersForSellerAsync(long id, string search)
        {
            try
            {
                var query = _context.Orders
                  .AsNoTracking()
                  .Include(x => x.OrderDetails)
                  .ThenInclude(x => x.Product)
                  .Include(x => x.Farmer)
                  .Where(u => u.SellerId == id);

                var queryDetails = query
                    .SelectMany(o => o.OrderDetails, (order, detail) => new { order, detail })
                    .Where(x => x.detail.Status == OrderStatus.Pending.ToString());

                if (!string.IsNullOrEmpty(search))
                {
                    queryDetails = queryDetails.Where(o => o.order.Farmer!.User!.FirstName!.Contains(search)
                                          || o.order.Farmer!.User!.LastName!.Contains(search)
                                            || o.detail.Product!.ProductName!.Contains(search));
                }


                var result = await queryDetails.Select(o => new OrderDTO

                {
                    OrderId = o.order.Id,
                    OrderDetailId = o.detail.Id,
                    Status = o.detail.Status,
                    product = new ProductViewModel
                    {
                        Id = o.detail.Product!.Id,
                        Number = o.detail.Number,
                        ImageProduct = o.detail.Product.ImageProduct,
                        Name = o.detail.Product.ProductName,
                    }
                           ,
                    farmer = new FarmerDTOForSeller
                    {
                        Id = o.order.Farmer!.Id,
                        Address = o.order.Farmer.Address,
                        ProfileImage = o.order.Farmer.ProfileImage,
                        Phone = o.order.Farmer.User!.Phone,
                        FirstName = o.order.Farmer.User!.FirstName,
                        CodePosti = o.order.Farmer.CodePosti,
                        LastName = o.order.Farmer.User!.LastName
                    }
                }
                    ).ToListAsync();
                return OperationResult<List<OrderDTO>>.SuccessedResult(result);



            }
            catch (Exception ex)
            {
                return OperationResult<List<OrderDTO>>.Failed(GetType().FullName!, ex);
            }

        }

        public async Task<OperationResult<List<OrderDTO>>> SelectNonPendingOrdersForSellerAsync(long id, string search)
        {

            try
            {
                var query = _context.Orders
                  .AsNoTracking()
                  .Include(x => x.OrderDetails)
                  .ThenInclude(x => x.Product)
                  .Include(x => x.Farmer)
                  .Where(u => u.SellerId == id);

                var queryDetails = query
                    .SelectMany(o => o.OrderDetails, (order, detail) => new { order, detail })
                    .Where(x => x.detail.Status != OrderStatus.Pending.ToString());

                if (!string.IsNullOrEmpty(search))
                {
                    queryDetails = queryDetails.Where(o => o.order.Farmer!.User!.FirstName!.Contains(search)
                                          || o.order.Farmer!.User!.LastName!.Contains(search)
                                            || o.detail.Product!.ProductName!.Contains(search));
                }


                var result = await queryDetails.Select(o => new OrderDTO

                {
                    OrderId = o.order.Id,
                    OrderDetailId = o.detail.Id,
                    Status = o.detail.Status,
                    product = new ProductViewModel
                    {
                        Id = o.detail.Product!.Id,
                        Number = o.detail.Number,
                        ImageProduct = o.detail.Product.ImageProduct,
                        Name = o.detail.Product.ProductName,
                    }
                           ,
                    farmer = new FarmerDTOForSeller
                    {
                        Id = o.order.Farmer!.Id,
                        Address = o.order.Farmer.Address,
                        ProfileImage = o.order.Farmer.ProfileImage,
                        Phone = o.order.Farmer.User!.Phone,
                        FirstName = o.order.Farmer.User!.FirstName,
                        CodePosti = o.order.Farmer.CodePosti,
                        LastName = o.order.Farmer.User!.LastName
                    }
                }
                    ).ToListAsync();
                return OperationResult<List<OrderDTO>>.SuccessedResult(result);



            }
            catch (Exception ex)
            {
                return OperationResult<List<OrderDTO>>.Failed(GetType().FullName!, ex);
            }
        }

        public async Task<OperationResult<long>> InsertAsync(FullCartItemDTO fullCartItemDTO)
        {
            try
            {
                var order = new Order
                {
                    FarmerId = fullCartItemDTO.FarmerId,
                    OrderDate =fullCartItemDTO.AddedDate,
                    SellerId = fullCartItemDTO.SellerId,
                };

                _context.Orders.AddRange(order);
                await _context.SaveChangesAsync();

                return OperationResult<long>.SuccessedResult(order.Id);
            }
            catch (Exception ex)
            {
                return OperationResult<long>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<long>> CheckOrderAsync(long farmerId, long SellerId)
        {
            try
            {
                var result = await _context
               .Orders
               .AsNoTracking()
               .Where(x => x.FarmerId == farmerId && x.SellerId == SellerId)
               .AnyAsync();
                if (result == false)
                {
                    return OperationResult<long>.FailedResult();
                }
                var result1 = await _context
              .Orders
              .AsNoTracking()
              .Where(x => x.FarmerId == farmerId && x.SellerId == SellerId).SingleAsync();
                return OperationResult<long>.SuccessedResult(result1.Id);
            }
            catch (Exception ex)
            {
                return OperationResult<long>.Failed(GetType().Name, ex);
            }
        }
    }
}
