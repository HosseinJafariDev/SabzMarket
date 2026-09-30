using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Common.Dtos;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.UseCases.Sellers.GetSeller;
using SabzMarket.Domain.Entities.Sellers;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories.Base;

namespace SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories;

public class SellerRepository(SabzMarketDbContext context)
    : RepositoryBase<Seller, long>(context), ISellerRepository
{
    public async Task<PagedResult<Seller>> GetPagedWithUserAsync(string? phone, string? username, int pageNumber,
        int pageSize, CancellationToken token)
    {
        var query = context.Sellers.AsQueryable();

        query.Include(x => x.User);

        if (!string.IsNullOrWhiteSpace(phone))
            query.Where(x => x.User!.Phone == phone);

        if (!string.IsNullOrWhiteSpace(phone))
            query.Where(x => username!.Contains(x.User!.UserName!));

        var count = await query.CountAsync(token);
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);

        return new PagedResult<Seller>(items, count);
    }

    public async Task<Seller?> GetWithUserAsync(long sellerId, CancellationToken token)
    {
        return await Context.Sellers.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == sellerId, token);
    }
}