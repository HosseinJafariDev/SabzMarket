using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.DAL.Entities;
using SabzMarket.Infrastructure.Persistence;
using SabzMarket.Share.Models;
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

        public async Task<OperationResult> DeleteAsync(long id)
        {
            try
            {
                var product = new Product { Id = id };
                _Context.Attach(product);
                product.IsDeleted = true;
                var entry = _Context.Entry(product);
                entry.Property(x => x.IsDeleted).IsModified = true;
                await _Context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }

        }

        public async Task<OperationResult<List<ProductDTO>>> GetAllBySellerAsync(long sellerId)
        {
            try
            {
                var result = await _Context.Products
                 .AsNoTracking()
                 .Where(p => p.SellerId == sellerId && p.IsDeleted == false).Select(p => new ProductDTO
                 {
                     SellerId = p.SellerId,
                     CategoryId = p.CategorieId,
                     Description = p.Description,
                     Id = p.Id,
                     ImageProduct = p.ImageProduct,
                     Name = p.ProductName,
                     Number = p.Number,
                     Price = p.Price
                 }).ToListAsync();
                return OperationResult<List<ProductDTO>>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ProductDTO>>.Failed();
            }


        }

        public async Task<OperationResult> IncreaseNumberAsync(long id, int number)
        {
            try
            {
                var result = await _Context.Products.Where(p => p.Id == id).SingleAsync();
                result.Number += number;
                await _Context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> InsertAsync(ProductDTO product)
        {
            try
            {
                Product product1 = new Product
                {
                    CategorieId = product.CategoryId,
                    Description = product.Description!,
                    ImageProduct = product.ImageProduct!,
                    Price = product.Price,
                    Number = product.Number,
                    ProductName = product.Name!,
                    SellerId = product.SellerId,
                };
                _Context.Products.Add(product1);
                await _Context.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }



        }

        public async Task<OperationResult<List<ProductDTO>>> SelectByNameAsync(string search)
        {
            try
            {
               var result=await _Context.Products.Where(x => x.ProductName!.Contains(search)&&x.IsDeleted==false).Select(x => new ProductDTO
                {
                    CategoryId=x.CategorieId,
                    Description=x.Description,
                    Id = x.Id,
                    ImageProduct=x.ImageProduct,
                    Name=x.ProductName,
                    Number = x.Number,
                    Price=x.Price,
                    SellerId = x.SellerId
                }).ToListAsync();
                return OperationResult<List<ProductDTO>>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<List<ProductDTO>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> UpdateAsync(ProductDTO product)
        {
            try
            {
                var produc = new Product
                {
                    Id = product.Id,
                    CategorieId = product.CategoryId,
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
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }

        }
    }
}
