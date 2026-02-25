using Microsoft.AspNetCore.Mvc;
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
        public async Task<OperationResult<List<GetOrdersForSellerOutputDTO>>> GetPendingOrdersForSellerAsync(long id, string search)
        {
            var result = await _getPendingOrdersForSellerUseCase.ExecuteAsync(id, search);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult<List<GetOrdersForSellerOutputDTO>>> GetNonPendingOrdersForSellerAsync(long id, string search)
        {
            var result = await _getNonPendingOrdersForSellerUseCase.ExecuteAsync(id, search);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult> CheckoutAsync(long farmerId)
        {
            var result = await _checkoutOrderUseCase.ExecuteAsync(farmerId);
            return result;
        }
    }
}
