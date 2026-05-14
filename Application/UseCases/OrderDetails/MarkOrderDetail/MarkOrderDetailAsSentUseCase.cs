using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail
{
    public class MarkOrderDetailAsSentUseCase : IMarkOrderDetailAsSentUseCase
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public MarkOrderDetailAsSentUseCase(IErrorRepository errorRepository, IOrderDetailRepository orderDetailRepository)
        {
            _errorRepository = errorRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<OperationResult> ExecuteAsync(long orderDetaileId, CancellationToken token)
        {
            try
            {
                await _orderDetailRepository.SetOrderDetailStatusToSentAsync(orderDetaileId, token);
                return OperationResult.SuccessedResult(Messages.OrderSent);
            }
            catch (Exception ex)
            {
                var errorReslt = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorReslt.ErrorMessage());
            }
        }
    }
}
