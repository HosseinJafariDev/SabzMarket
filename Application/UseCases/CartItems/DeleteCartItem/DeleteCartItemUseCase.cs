using Application.Interfaces.Repositories;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
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
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCartItemUseCase(
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> ExecuteAsync(int cartId, long productId, int productNumber,
            CancellationToken token)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _cartItemRepository.DeleteAsync(cartId, token);
                await _productRepository.IncreaseNumberAsync(productId, productNumber, token);
                await _unitOfWork.CommitAsync();
                return OperationResult.Success(OperationError.None, Messages.RemoveAddToCart);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}