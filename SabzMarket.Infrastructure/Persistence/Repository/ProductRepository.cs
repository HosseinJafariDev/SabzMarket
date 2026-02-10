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
    public class ProductRepository : IProductRepository
    {
        private readonly SabzMarketDbContext _Context;
        public ProductRepository(SabzMarketDbContext context)
        {
            _Context = context;
        }

        public async Task DeleteAsync(long id)
        {
            var product = new Product { Id = id };
            _Context.Attach(product);
            product.IsDeleted = true;
            var entry = _Context.Entry(product);
            entry.Property(x => x.IsDeleted).IsModified = true;
            await _Context.SaveChangesAsync();
        }

        public async Task<List<Product>> SelectAllBySellerIdAsync(long sellerId)
        {
            var result = await _Context.Products
             .AsNoTracking()
             .Where(p => p.SellerId == sellerId && p.IsDeleted == false).Select(p => new Product
             {
                 SellerId = p.SellerId,
                 CategorieId = p.CategorieId,
                 Description = p.Description,
                 Id = p.Id,
                 ImageProduct = p.ImageProduct,
                 Name = p.ProductName,
                 Number = p.Number,
                 Price = p.Price
             }).ToListAsync();
            return result;
        }

        public async Task IncreaseNumberAsync(long id, int number)
        {
            var result = await _Context.Products.Where(p => p.Id == id).SingleAsync();
            result.Number += number;
            await _Context.SaveChangesAsync();
        }

        public async Task InsertAsync(Product product)
        {
            ProductTable product1 = new ProductTable
            {
                CategorieId = product.CategorieId,
                Description = product.Description!,
                ImageProduct = product.ImageProduct!,
                Price = product.Price,
                Number = product.Number,
                ProductName = product.Name!,
                SellerId = product.SellerId,
            };
            _Context.Products.Add(product1);
            await _Context.SaveChangesAsync();
        }

        public async Task<List<Product>> SelectByNameAsync(string search)
        {
            var result = await _Context
            .Products
            .Where(x => x.ProductName!.Contains(search) && x.IsDeleted == false)
            .Select(x => new Product
            {
                CategorieId = x.CategorieId,
                Description = x.Description,
                Id = x.Id,
                ImageProduct = x.ImageProduct,
                Name = x.ProductName,
                Number = x.Number,
                Price = x.Price,
                SellerId = x.SellerId
            }).ToListAsync();
            return result;
        }

        public async Task UpdateAsync(Product product)
        {
            var produc = new ProductTable
            {
                Id = product.Id,
                CategorieId = product.CategorieId,
                ImageProduct = product.ImageProduct,
                Number = product.Number,
                Price = product.Price,
                ProductName = product.Name,
                SellerId = product.SellerId,
            };
            _Context.Attach(produc);
            var entry = _Context.Entry(produc);
            entry.Property(x => x.Number).IsModified = true;
            entry.Property(x => x.SellerId).IsModified = true;
            entry.Property(x => x.ProductName).IsModified = true;
            entry.Property(x => x.Price).IsModified = true;
            entry.Property(x => x.ImageProduct).IsModified = true;
            entry.Property(x => x.CategorieId).IsModified = true;
            entry.Property(x => x.CategorieId).IsModified = true;
            await _Context.SaveChangesAsync();
        }

    }
}
