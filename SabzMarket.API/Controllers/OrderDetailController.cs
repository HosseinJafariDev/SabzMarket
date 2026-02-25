using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail;

namespace SabzMarket.API.Controllers
{
    public class OrderDetailController : BaseController
    {
        private readonly IMarkOrderDetailAsRejectedUseCase _markOrderDetailAsRejectedUseCase;
        private readonly IMarkOrderDetailAsSent _markOrderDetailAsSent;
        public OrderDetailController(
            IMarkOrderDetailAsRejectedUseCase markOrderDetailAsRejectedUseCase,
            IMarkOrderDetailAsSent markOrderDetailAsSent)
        {
            _markOrderDetailAsRejectedUseCase = markOrderDetailAsRejectedUseCase;
            _markOrderDetailAsSent = markOrderDetailAsSent;
        }
        [HttpGet]
        public async Task<OperationResult> MarkOrderDetailAsRejectedAsync(long orderDetaileId, int number, int productId)
        {
            var result = await _markOrderDetailAsRejectedUseCase.ExecuteAsync(orderDetaileId, number, productId);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult> MarkOrderDetailAsSentAsync(long orderDetaileId)
        {
            var result = await _markOrderDetailAsSent.ExecuteAsync(orderDetaileId);
            return result;
        }
    }
}
