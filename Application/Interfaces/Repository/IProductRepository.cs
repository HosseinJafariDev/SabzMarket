using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        public Task InsertAsync(Product product);
        public Task IncreaseNumberAsync(long id, int number);
        public Task<List<Product>> SelectAllBySellerIdAsync(long sellerId);
        public Task DeleteAsync(long id);
        public Task UpdateAsync(Product product);
        public Task<List<Product>> SelectByNameAsync(string search);
    }
}
