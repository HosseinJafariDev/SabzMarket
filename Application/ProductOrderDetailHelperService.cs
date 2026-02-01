using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Repository;
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
    public class ProductOrderDetailHelperService : IProductOrderDetailHelperService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IErrorService _errorService;
        public ProductOrderDetailHelperService(IProductRepository productRepository, IOrderDetailRepository orderDetailRepository, IErrorService errorService)
        {
            _productRepository= productRepository;
            _orderDetailRepository= orderDetailRepository;
            _errorService= errorService;
        }

        public async Task<OperationResult> HasPendingOrdersForProductAsync(long productId)
        {
            var result = await _orderDetailRepository.HasPendingOrdersForProductAsync(productId);
            if (!result.Success)
            {
                if (!result.Result)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var resulterror = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(resulterror.Message!);
                }
                return OperationResult.FailedResult();
            }
            return OperationResult.SuccessedResult();
        }

        public async Task<OperationResult> IncreaseNumberAsync(long id, int number)
        {
            var result = await _productRepository.IncreaseNumberAsync(id, number);

            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resultError = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(resultError.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult();
        }
    }
}
