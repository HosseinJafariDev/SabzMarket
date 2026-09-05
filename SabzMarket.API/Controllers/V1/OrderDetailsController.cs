using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail;

namespace SabzMarket.API.Controllers.V1
{
    [Authorize]
    public class OrderDetailsController : BaseController
    {
        private readonly IMarkOrderDetailAsRejectedUseCase _markOrderDetailAsRejectedUseCase;
        private readonly IMarkOrderDetailAsSentUseCase _markOrderDetailAsSent;

        public OrderDetailsController(
            IMarkOrderDetailAsRejectedUseCase markOrderDetailAsRejectedUseCase,
            IMarkOrderDetailAsSentUseCase markOrderDetailAsSent)
        {
            _markOrderDetailAsRejectedUseCase = markOrderDetailAsRejectedUseCase;
            _markOrderDetailAsSent = markOrderDetailAsSent;
        }

        [HttpGet("{orderDetailId:long}/reject")]
        public async Task<ApiResult> MarkOrderDetailAsRejected(long orderDetaileId, int number, int productId,
            CancellationToken token)
        {
            var result = await _markOrderDetailAsRejectedUseCase.ExecuteAsync(orderDetaileId, number, productId, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet("{orderDetailId:long}/send")]
        public async Task<ApiResult> MarkOrderDetailAsSent(long orderDetaileId, CancellationToken token)
        {
            var result = await _markOrderDetailAsSent.ExecuteAsync(orderDetaileId, token);
            return result.OperationResultTOApiResult();
        }
    }
}