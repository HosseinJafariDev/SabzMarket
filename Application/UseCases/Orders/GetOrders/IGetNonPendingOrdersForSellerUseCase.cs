using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Orders.GetOrders
{
    public interface IGetNonPendingOrdersForSellerUseCase
    {
        Task<OperationResult<List<GetOrdersForSellerOutputDTO>>> ExecuteAsync(long sellerId, string search);
    }
}
