using SabzMarket.Domain.Entities.Farmers;
using SabzMarket.Application.Interfaces.Persistence;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IFarmerRepository : IRepository<Farmer, long>
    {
    }
}