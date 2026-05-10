using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        public Task InsertAsync(Product product, CancellationToken token);
        public Task IncreaseNumberAsync(long id, int number, CancellationToken token);
        public Task<List<Product>> SelectAllBySellerIdAsync(long sellerId);
        public Task DeleteAsync(long id, CancellationToken token);
        public Task UpdateAsync(Product product, CancellationToken token);
        public Task<List<Product>> SelectByNameAsync(string search, CancellationToken token);
    }
}
