using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IOrderRepository
    {
        public Task<long> InsertAsync(Order order, CancellationToken token);
        public Task<bool> CheckOrderAsync(long farmerId, long SellerId);
        Task<long> FindOrderByFarmerAndSellerAsync(long farmerId, long SellerId, CancellationToken token);
    }
}
