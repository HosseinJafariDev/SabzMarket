using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail
{
    public class MarkOrderDetailAsSentUseCase : IMarkOrderDetailAsSentUseCase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public MarkOrderDetailAsSentUseCase(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OperationResult> ExecuteAsync(long orderDetaileId, CancellationToken token)
        {
            await _orderDetailRepository.SetOrderDetailStatusToSentAsync(orderDetaileId, token);
            return OperationResult.Success(OperationError.None, Messages.OrderSent);
        }
    }
}