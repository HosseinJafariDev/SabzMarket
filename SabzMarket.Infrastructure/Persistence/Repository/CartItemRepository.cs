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
        public async Task DeleteAsync(int cartId, CancellationToken token)
        {
            CartItemTable item = new CartItemTable()
            {
                Id = cartId
            };
            _Context.Remove(item);
            await _Context.SaveChangesAsync(token);
        }
        public async Task<bool> ExistProductAsync(long farmerId, long productId, CancellationToken token)
        {
            var result = await _Context
           .CartItems
           .AsNoTracking()
           .Where(x => x.ProductId == productId && x.FarmerId == farmerId)
           .AnyAsync(token);

            return result;
        }
        public async Task InsertAsync(CartItem cartItem, CancellationToken token)
        {
            CartItemTable cartItemTable = new CartItemTable()
            {
                AddedDate = cartItem.AddedDate,
                FarmerId = cartItem.FarmerId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity
            };
            _Context.CartItems.Add(cartItemTable);
            await _Context.SaveChangesAsync(token);
        }
        public async Task ChangeQuantityAsync(long productId, long farmerId, int number, CancellationToken token)
        {
            var item = await _Context
            .CartItems
            .Where(x => x.ProductId == productId && x.FarmerId == farmerId)
            .SingleAsync();

            item.Quantity += number;

            await _Context.SaveChangesAsync(token);
        }
        public async Task<bool> IsCartItemQuantityOneAsync(int id, CancellationToken token)
        {
            var item = await _Context
                .CartItems
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleAsync(token);
            if (item.Quantity == 1)
            {
                return true;
            }
            return false;
        }
    }
}
