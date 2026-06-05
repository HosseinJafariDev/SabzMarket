using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
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
        public async Task<ApiResult> MarkOrderDetailAsRejectedAsync(long orderDetaileId, int number, int productId, CancellationToken token)
        {
            var result = await _markOrderDetailAsRejectedUseCase.ExecuteAsync(orderDetaileId, number, productId, token);
            return result.OperationResultTOApiResult();
        }
        [HttpGet]
        public async Task<ApiResult> MarkOrderDetailAsSentAsync(long orderDetaileId, CancellationToken token)
        {
            var result = await _markOrderDetailAsSent.ExecuteAsync(orderDetaileId, token);
            return result.OperationResultTOApiResult();
        }
    }
}
