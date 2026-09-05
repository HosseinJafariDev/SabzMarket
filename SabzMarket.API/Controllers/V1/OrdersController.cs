using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Orders.Checkout;
using SabzMarket.Application.UseCases.Orders.GetOrders;

namespace SabzMarket.API.Controllers.V1
{
    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IGetPendingOrdersForSellerUseCase _getPendingOrdersForSellerUseCase;
        private readonly IGetNonPendingOrdersForSellerUseCase _getNonPendingOrdersForSellerUseCase;
        private readonly ICheckoutOrderUseCase _checkoutOrderUseCase;

        public OrdersController(
            IGetPendingOrdersForSellerUseCase getPendingOrdersForSellerUseCase,
            IGetNonPendingOrdersForSellerUseCase getNonPendingOrdersForSellerUseCase,
            ICheckoutOrderUseCase checkoutOrderUseCase)
        {
            _getPendingOrdersForSellerUseCase = getPendingOrdersForSellerUseCase;
            _getNonPendingOrdersForSellerUseCase = getNonPendingOrdersForSellerUseCase;
            _checkoutOrderUseCase = checkoutOrderUseCase;
        }

        [HttpGet("{sellerId:long}/pending-orders")]
        public async Task<ApiResult<List<GetOrdersForSellerOutputDTO>>> GetPendingOrdersForSeller(long sellerId,
            string search, CancellationToken token)
        {
            var result = await _getPendingOrdersForSellerUseCase
                .ExecuteAsync(sellerId, search, token);

            return result.OperationResultTOApiResult();
        }

        [HttpGet("{sellerId:long}/non-pending-orders")]
        public async Task<ApiResult<List<GetOrdersForSellerOutputDTO>>> GetNonPendingOrdersForSeller(long sellerId,
            string search, CancellationToken token)
        {
            var result = await _getNonPendingOrdersForSellerUseCase
                .ExecuteAsync(sellerId, search, token);

            return result.OperationResultTOApiResult();
        }

        [HttpPost("{farmerId:long}")]
        public async Task<ApiResult> Checkout(long farmerId, CancellationToken token)
        {
            var result = await _checkoutOrderUseCase
                .ExecuteAsync(farmerId, token);

            return result.OperationResultTOApiResult();
        }
    }
}