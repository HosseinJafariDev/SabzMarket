using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.UseCases.Products.GetProduct;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product, long>
    {
        Task<IReadOnlyList<Product>> GetAllAsync(long? sellerId, string? searchName, int pageNumber,
            int pageSize, CancellationToken token);
    }
}