using Microsoft.IdentityModel.Tokens.Experimental;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail
{
    public class MarkOrderDetailAsRejectedUseCase : IMarkOrderDetailAsRejectedUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IProductRepository _productRepository;
        public MarkOrderDetailAsRejectedUseCase(
            IUnitOfWork unitOfWork,
            IOrderDetailRepository orderDetailRepository,
            IErrorRepository errorRepository,
            IProductRepository productRepository)
        {
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }
        public async Task<OperationResult> ExecuteAsync(long orderDetaileId, int number, int productId)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                var result = await _orderDetailRepository.StatusIsReject(orderDetaileId);
                if (result)
                {
                    return OperationResult.FailedResult(Messages.OrderAlreadyRejectedMessage);
                }
                await _orderDetailRepository.SetOrderDetailStatusToRejectedAsync(orderDetaileId);
                await _productRepository.IncreaseNumberAsync(productId, number);
                await _unitOfWork.CommitAsync();
                return OperationResult.SuccessedResult(Messages.OrderReject);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
