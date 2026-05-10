using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IOrderDetailRepository
    {
        public Task SetOrderDetailStatusToSentAsync(long orderDetile, CancellationToken token);
        public Task SetOrderDetailStatusToRejectedAsync(long orderDetile, CancellationToken token);
        public Task<bool> HasPendingOrdersForProductAsync(long productId);
        public Task InsertAsync(OrderDetail orderDetail, CancellationToken token);
        Task<bool> StatusIsReject(long id);
        Task<bool> StatusIsSent(long id);
    }
}
