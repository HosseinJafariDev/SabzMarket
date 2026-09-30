using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Products;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories.Base;

namespace SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories;

public class ProductRepository(SabzMarketDbContext context) : RepositoryBase<Product, long>(context) ,IProductRepository
{
}