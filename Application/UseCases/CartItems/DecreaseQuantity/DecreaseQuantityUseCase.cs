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

namespace SabzMarket.Application.UseCases.CartItems.DecreaseQuantity
{
    public class DecreaseQuantityUseCase : IDecreaseQuantityUseCase
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DecreaseQuantityUseCase(
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository,
            IErrorRepository errorRepository,
            IUnitOfWork unitOfWork)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> ExecuteAsync(long productId, long farmerId, CancellationToken token)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _cartItemRepository.ChangeQuantityAsync(productId, farmerId, -1, token);
                await _productRepository.IncreaseNumberAsync(productId, 1, token);
                await _unitOfWork.CommitAsync();
                return OperationResult.Success(OperationError.None, Messages.RemoveAddToCart);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(OperationError.ServerError, errorResult.ErrorMessage());
            }

        }
    }
}
