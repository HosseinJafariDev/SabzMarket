using Application.Interfaces.Repositories;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Persistence;
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
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCartItemUseCase(
            ICartItemRepository cartItemRepository,
            IErrorRepository errorRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _cartItemRepository = cartItemRepository;
            _errorRepository = errorRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> ExecuteAsync(int cartId, long productId, int productNumber, CancellationToken token)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _cartItemRepository.DeleteAsync(cartId, token);
                await _productRepository.IncreaseNumberAsync(productId, productNumber, token);
                await _unitOfWork.CommitAsync();
                return OperationResult.SuccessedResult(Messages.RemoveAddToCart);
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
