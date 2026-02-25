using Application.Interfaces.Repositories;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.DeleteCartItem
{
    public class DeleteCartItemUseCase : IDeleteCartItemUseCase
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IProductRepository _productRepository;
        public DeleteCartItemUseCase(
            ICartItemRepository cartItemRepository,
            IErrorRepository errorRepository,
            IProductRepository productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _errorRepository = errorRepository;
            _productRepository = productRepository;
        }
        public async Task<OperationResult> ExecuteAsync(int cartId, long productId, int productNumber)
        {
            try
            {
                await _cartItemRepository.DeleteAsync(cartId);
                await _productRepository.IncreaseNumberAsync(productId, productNumber);
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
