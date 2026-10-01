using MongoDB.Driver.Linq;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Products;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories.Base;

namespace SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories;

public class ProductRepository(SabzMarketDbContext context) : RepositoryBase<Product, long>(context), IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAllAsync(long? sellerId, string? searchName, int pageNumber,
        int pageSize,
        CancellationToken token)
    {
        var query = Context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(searchName))
            query = query.Where(p => p.Name.Contains(searchName));

        if (sellerId is not null)
            query = query.Where(p => p.SellerId == sellerId);

        var products = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);

        return products;
    }
}