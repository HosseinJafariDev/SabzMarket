using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Application.UseCases.Orders.GetOrders
{
    public class GetNonPendingOrdersForSellerUseCase : IGetNonPendingOrdersForSellerUseCase
    {
        private readonly IOrderQueryService _orderQueryService;

        public GetNonPendingOrdersForSellerUseCase(IOrderQueryService orderQueryService)
        {
            _orderQueryService = orderQueryService;
        }

        public async Task<OperationResult<List<GetOrdersForSellerOutputDTO>>> ExecuteAsync(long sellerId, string search,
            CancellationToken token)
        {
            var orders = await _orderQueryService
                .SelectNonPendingOrdersForSellerAsync(sellerId, search, token);

            if (!orders.Any())
                throw new NotFoundException(Messages.NotFoundPendingOrders);

            return OperationResult<List<GetOrdersForSellerOutputDTO>>
                .Success(orders, OperationError.Success);
        }
    }
}