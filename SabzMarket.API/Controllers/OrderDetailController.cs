using Microsoft.AspNetCore.Mvc;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail;

namespace SabzMarket.API.Controllers
{
    public class OrderDetailController : BaseController
    {
        private readonly IMarkOrderDetailAsRejectedUseCase _markOrderDetailAsRejectedUseCase;
        private readonly IMarkOrderDetailAsSentUseCase _markOrderDetailAsSent;
        public OrderDetailController(
            IMarkOrderDetailAsRejectedUseCase markOrderDetailAsRejectedUseCase,
            IMarkOrderDetailAsSentUseCase markOrderDetailAsSent)
        {
            _markOrderDetailAsRejectedUseCase = markOrderDetailAsRejectedUseCase;
            _markOrderDetailAsSent = markOrderDetailAsSent;
        }
        [HttpGet]
        public async Task<OperationResult> MarkOrderDetailAsRejectedAsync(long orderDetaileId, int number, int productId, CancellationToken token)
        {
            var result = await _markOrderDetailAsRejectedUseCase.ExecuteAsync(orderDetaileId, number, productId, token);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult> MarkOrderDetailAsSentAsync(long orderDetaileId, CancellationToken token)
        {
            var result = await _markOrderDetailAsSent.ExecuteAsync(orderDetaileId, token);
            return result;
        }
    }
}
