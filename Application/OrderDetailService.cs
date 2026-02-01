using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Share;
using SabzMarket.Share.ErrorHandling;
using SabzMarket.Share.Mappers;
using SabzMarket.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IErrorService _errorService;
        private readonly IProductOrderDetailHelperService _productOrderDetailHelperService;
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailService(
            IOrderDetailRepository orderDetailRepository,
            IErrorService errorService,
            IProductOrderDetailHelperService productOrderDetailHelperService,
            IUnitOfWork unitOfWork)
        {
            _orderDetailRepository = orderDetailRepository;
            _errorService = errorService;
            _productOrderDetailHelperService = productOrderDetailHelperService;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> InsertAsync(FullCartItemDTO fullCartItemDTOs, long orderId)
        {
            var result = await _orderDetailRepository.InsertAsync(fullCartItemDTOs, orderId);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult();
        }

        public async Task<OperationResult> MarkOrderDetailAsRejectedAsync(long orderDetaileId, int number, int productId)
        {
            await _unitOfWork.BeginAsync();
            var result = await _orderDetailRepository.SetOrderDetailStatusToRejectedAsync(orderDetaileId);
            if (!result.Success)
            {
                await _unitOfWork.RollbackAsync();
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            var result1 = await _productOrderDetailHelperService.IncreaseNumberAsync(productId, number);
            if (!result1.Success)
            {
                await _unitOfWork.RollbackAsync();
                return result1;
            }
            await _unitOfWork.CommitAsync();
            return OperationResult.SuccessedResult(true, Messages.RejectedOrder);

        }

        public async Task<OperationResult> MarkOrderDetailAsSentAsync(long orderDetaileId)
        {
            var result = await _orderDetailRepository.SetOrderDetailStatusToSentAsync(orderDetaileId);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, Messages.SentOrder);
        }
    }
}
