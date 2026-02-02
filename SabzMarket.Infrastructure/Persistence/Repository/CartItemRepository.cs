using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.DAL.Entities;
using SabzMarket.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly SabzMarketDbContext _Context;
        public CartItemRepository(SabzMarketDbContext Context)
        {
            _Context = Context;
        }

        public async Task<OperationResult> DeleteAsync(int cartId)
        {
            try
            {
                CartItem item = new CartItem()
                {
                    Id = cartId
                };
                _Context.Remove(item);
                await _Context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }

        }

        public async Task<OperationResult> ExistProductAsync(long farmer, long productId)
        {
            try
            {
                var result = await _Context
               .CartItems
               .AsNoTracking()
               .Where(x => x.ProductId == productId && x.FarmerId == farmer)
               .AnyAsync();
                return OperationResult.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }



        public async Task<OperationResult> InsertAsync(CartItemDTO cartItemDTO)
        {
            try
            {
                CartItem cartItem = new CartItem()
                {
                    AddedDate = cartItemDTO.AddedDate,
                    FarmerId = cartItemDTO.FarmerId,
                    Id = cartItemDTO.Id,
                    ProductId = cartItemDTO.ProductId,
                    Quantity = 1
                };
                _Context.Add(cartItem);
                await _Context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> ChangeQuantityAsync(long productId, long farmerId, int number)
        {
            try
            {
                var item = await _Context.CartItems.Where(x => x.ProductId == productId && x.FarmerId == farmerId).SingleAsync();
                item.Quantity += number;
                await _Context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }

        }

        public async Task<OperationResult> IsCartItemQuantityOneAsync(int id)
        {
            try
            {
                var item = await _Context.CartItems.AsNoTracking().Where(x => x.Id == id).SingleAsync();
                if (item.Quantity == 1)
                    return OperationResult.SuccessedResult(true);
                return OperationResult.SuccessedResult(false);
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<List<FullCartItemDTO>>> SelectByFarmerIdAsync(long farmerId)
        {
            try
            {
                var result = await _Context
                    .CartItems
                    .AsNoTracking()
                    .Where(x =>
                    x.FarmerId == farmerId &&
                    x.Product.IsDeleted == false)
                    .Select(x => new FullCartItemDTO()
                    {
                        FarmerId = farmerId,
                        SellerId = x.Product.SellerId,
                        AddedDate = x.AddedDate,
                        Id = x.Id,
                        ProductId = x.ProductId,
                        ProductImage = x.Product.ImageProduct,
                        ProductName = x.Product.ProductName,
                        ProductPrice = x.Product.Price,
                        Quantity = x.Quantity,
                        ProducNumber=x.Product.Number
                    }).ToListAsync();
                return OperationResult<List<FullCartItemDTO>>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<List<FullCartItemDTO>>.Failed(GetType().Name, ex);
            }
        }
    }
}
