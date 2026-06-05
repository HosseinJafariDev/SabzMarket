using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Orders.Checkout;
using SabzMarket.Application.UseCases.Orders.GetOrders;

namespace SabzMarket.API.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IGetPendingOrdersForSellerUseCase _getPendingOrdersForSellerUseCase;
        private readonly IGetNonPendingOrdersForSellerUseCase _getNonPendingOrdersForSellerUseCase;
        private readonly ICheckoutOrderUseCase _checkoutOrderUseCase;
        public OrderController(
            IGetPendingOrdersForSellerUseCase getPendingOrdersForSellerUseCase,
            IGetNonPendingOrdersForSellerUseCase getNonPendingOrdersForSellerUseCase,
            ICheckoutOrderUseCase checkoutOrderUseCase)
        {
            _getPendingOrdersForSellerUseCase = getPendingOrdersForSellerUseCase;
            _getNonPendingOrdersForSellerUseCase = getNonPendingOrdersForSellerUseCase;
            _checkoutOrderUseCase = checkoutOrderUseCase;
        }
        [HttpGet]
        public async Task<ApiResult<List<GetOrdersForSellerOutputDTO>>> GetPendingOrdersForSellerAsync(long id, string search, CancellationToken token)
        {
            var result = await _getPendingOrdersForSellerUseCase
                .ExecuteAsync(id, search, token);

            return result.OperationResultTOApiResult();
        }
        [HttpGet]
        public async Task<ApiResult<List<GetOrdersForSellerOutputDTO>>> GetNonPendingOrdersForSellerAsync(long id, string search, CancellationToken token)
        {
            var result = await _getNonPendingOrdersForSellerUseCase
                .ExecuteAsync(id, search, token);

            return result.OperationResultTOApiResult();
        }
        [HttpGet]
        public async Task<ApiResult> CheckoutAsync(long farmerId, CancellationToken token)
        {
            var result = await _checkoutOrderUseCase
                .ExecuteAsync(farmerId, token);

            return result.OperationResultTOApiResult();
        }
    }
}
