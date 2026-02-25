using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Orders.GetOrders
{
    public class GetNonPendingOrdersForSellerUseCase : IGetNonPendingOrdersForSellerUseCase
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly IErrorRepository _errorRepository;
        public GetNonPendingOrdersForSellerUseCase(IOrderQueryService orderQueryService, IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
            _orderQueryService = orderQueryService;
        }
        public async Task<OperationResult<List<GetOrdersForSellerOutputDTO>>> ExecuteAsync(long sellerId, string search)
        {
            try
            {
                var orders = await _orderQueryService.SelectNonPendingOrdersForSellerAsync(sellerId, search);
                return OperationResult<List<GetOrdersForSellerOutputDTO>>.SuccessedResult(orders);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<List<GetOrdersForSellerOutputDTO>>.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
