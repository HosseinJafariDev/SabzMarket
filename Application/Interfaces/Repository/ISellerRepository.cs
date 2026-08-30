using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Sellers;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ISellerRepository : IRepository<Seller, long>
    {
    }
}