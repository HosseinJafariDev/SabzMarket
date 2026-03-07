using Application.Interfaces.Repositories;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Persistence;
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
        public async Task<OperationResult> ExecuteAsync(long productId, long farmerId)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _cartItemRepository.ChangeQuantityAsync(productId, farmerId, -1);
                await _productRepository.IncreaseNumberAsync(farmerId, 1);
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
