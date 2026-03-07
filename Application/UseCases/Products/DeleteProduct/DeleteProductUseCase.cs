using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.DeleteProduct
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IErrorRepository _errorRepository;
        public DeleteProductUseCase(IProductRepository productRepository, IOrderDetailRepository orderDetailRepository, IErrorRepository errorRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _errorRepository = errorRepository;
        }
        public async Task<OperationResult> ExecuteAsync(long id)
        {
            try
            {
                var hasPendingOrders = await _orderDetailRepository.HasPendingOrdersForProductAsync(id);
                if (hasPendingOrders)
                {
                    return OperationResult.FailedResult(Messages.ProductIsOnOrder);
                }

                await _productRepository.DeleteAsync(id);
                return OperationResult.SuccessedResult(Messages.ProductDelete);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
