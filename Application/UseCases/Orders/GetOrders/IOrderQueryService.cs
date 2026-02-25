using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Orders.GetOrders
{
    public interface IOrderQueryService
    {
        Task<List<GetOrdersForSellerOutputDTO>> SelectPendingOrdersForSellerAsync(long sellerId, string search);
        Task<List<GetOrdersForSellerOutputDTO>> SelectNonPendingOrdersForSellerAsync(long sellerId, string search);
    }
}
