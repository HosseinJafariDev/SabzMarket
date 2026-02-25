using Application.Interfaces.Repositories;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.DecreaseQuantity
{
    public class DecreaseQuantityUseCase : IDecreaseQuantityUseCase
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IErrorRepository _errorRepository;
        public DecreaseQuantityUseCase(
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository,
            IErrorRepository errorRepository)
        {
            _cartItemRepository= cartItemRepository;
            _productRepository= productRepository;
            _errorRepository= errorRepository;
        }
        public async Task<OperationResult> ExecuteAsync(long productId, long farmerId)
        {
            try
            {
                await _cartItemRepository.ChangeQuantityAsync(productId, farmerId, -1);
                await _productRepository.IncreaseNumberAsync(farmerId, 1);
                return OperationResult.SuccessedResult(true, Messages.RemoveAddToCart);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }

        }
    }
}
