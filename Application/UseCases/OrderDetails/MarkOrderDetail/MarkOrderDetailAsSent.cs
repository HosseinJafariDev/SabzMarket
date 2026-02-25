using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail
{
    public class MarkOrderDetailAsSent : IMarkOrderDetailAsSent
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public MarkOrderDetailAsSent(IErrorRepository errorRepository, IOrderDetailRepository orderDetailRepository)
        {
            _errorRepository = errorRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<OperationResult> ExecuteAsync(long orderDetaileId)
        {
            try
            {
                await _orderDetailRepository.SetOrderDetailStatusToSentAsync(orderDetaileId);
                return OperationResult.SuccessedResult(true, Messages.OrderSent);
            }
            catch (Exception ex)
            {
                var errorReslt = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorReslt.ErrorMessage());
            }
        }
    }
}
