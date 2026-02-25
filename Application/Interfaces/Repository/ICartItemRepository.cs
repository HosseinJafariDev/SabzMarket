using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ICartItemRepository
    {
        public Task InsertAsync(CartItem cartItem);
        public Task ChangeQuantityAsync(long productId, long farmerId, int number);
        public Task DeleteAsync(int cartId);
        public Task<bool> ExistProductAsync(long farmerId, long productId);
        public Task<bool> IsCartItemQuantityOneAsync(int id);
    }
}
