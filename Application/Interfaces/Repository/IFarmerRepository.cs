using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Buyer;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IFarmerRepository : IRepository<Buyer, long>
    {
    }
}