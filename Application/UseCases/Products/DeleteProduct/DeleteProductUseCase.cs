using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Exceptions;
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
        public DeleteProductUseCase(IProductRepository productRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }
        public async Task<OperationResult> ExecuteAsync(long id, CancellationToken token)
        {
            var hasPendingOrders = await _orderDetailRepository.HasPendingOrdersForProductAsync(id, token);

            if (hasPendingOrders)
                throw new ConflictException(Messages.ProductIsOnOrder);

            await _productRepository.DeleteAsync(id, token);
            return OperationResult.Success(OperationError.None, Messages.ProductDelete);
        }
    }
}
