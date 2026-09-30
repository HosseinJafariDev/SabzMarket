using SabzMarket.Application.Common.Dtos;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.UseCases.Sellers.GetSeller;
using SabzMarket.Domain.Entities.Sellers;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ISellerRepository : IRepository<Seller, long>
    {
        Task<PagedResult<Seller>> GetPagedWithUserAsync(string? phone, string? username, int pageNumber, int pageSize,
            CancellationToken token);
        
        Task<Seller?> GetWithUserAsync(long sellerId, CancellationToken token);
    }
}