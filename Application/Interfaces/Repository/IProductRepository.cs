using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product, long>
    {
    }
}