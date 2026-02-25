using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Entities;
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
        public async Task DeleteAsync(int cartId)
        {
            CartItemTable item = new CartItemTable()
            {
                Id = cartId
            };
            _Context.Remove(item);
            await _Context.SaveChangesAsync();
        }
        public async Task<bool> ExistProductAsync(long farmerId, long productId)
        {
            var result = await _Context
           .CartItems
           .AsNoTracking()
           .Where(x => x.ProductId == productId && x.FarmerId == farmerId)
           .AnyAsync();

            return result;
        }
        public async Task InsertAsync(CartItem cartItem)
        {
            CartItemTable cartItemTable = new CartItemTable()
            {
                AddedDate = cartItem.AddedDate,
                FarmerId = cartItem.FarmerId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity
            };
            _Context.Add(cartItemTable);
            await _Context.SaveChangesAsync();
        }
        public async Task ChangeQuantityAsync(long productId, long farmerId, int number)
        {
            var item = await _Context
            .CartItems
            .Where(x => x.ProductId == productId && x.FarmerId == farmerId)
            .SingleAsync();

            item.Quantity += number;

            await _Context.SaveChangesAsync();
        }
        public async Task<bool> IsCartItemQuantityOneAsync(int id)
        {
            var item = await _Context
                .CartItems
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleAsync();
            if (item.Quantity == 1)
            {
                return true;
            }
            return false;
        }
    }
}
