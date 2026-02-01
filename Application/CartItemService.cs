using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Share;
using SabzMarket.Share.ErrorHandling;
using SabzMarket.Share.Mappers;
using SabzMarket.Share.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _repository;
        private readonly IErrorService _errorService;
        private readonly IProductOrderDetailHelperService _productOrderDetailHelperService;
        public CartItemService(
            ICartItemRepository repository,
            IErrorService errorService,
            IProductOrderDetailHelperService productOrderDetailHelperService)
        {
            _repository = repository;
            _errorService = errorService;
            _productOrderDetailHelperService = productOrderDetailHelperService;
        }
        public async Task<OperationResult> AddToCartAsync(CartItemDTO cartItemDTO)
        {
            var exist = await _repository.ExistProductAsync(cartItemDTO.FarmerId, cartItemDTO.ProductId);
            if (!exist.Success)
            {

                if (!exist.Result)
                {
                    var error = exist.Exception!.ExceptionToErrorDTO(exist.Message!);
                    var errorResult = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(errorResult.Message!.ErrorMessage());
                }

                var result1 = await _repository.InsertAsync(cartItemDTO);
                if (!result1.Success)
                {
                    var error = result1.Exception!.ExceptionToErrorDTO(result1.Message!);
                    var errorResult = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(errorResult.Message!.ErrorMessage());
                }
                return OperationResult.SuccessedResult(true, Messages.successAddToCart);
            }

            var result2 = await _repository.ChangeQuantityAsync(cartItemDTO.ProductId, cartItemDTO.FarmerId, 1);
            if (!result2.Success)
            {
                var error = result2.Exception!.ExceptionToErrorDTO(result2.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, Messages.successAddToCart);

        }

        public async Task<OperationResult> DecreaseQuantityAsync(long productId, long farmerId)
        {
            var result2 = await _repository.ChangeQuantityAsync(productId, farmerId, -1);
            if (!result2.Success)
            {
                var error = result2.Exception!.ExceptionToErrorDTO(result2.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            var resultIncrease = await _productOrderDetailHelperService.IncreaseNumberAsync(productId, 1);
            if (!resultIncrease.Success)
            {
                return OperationResult.Failed(resultIncrease.Message!);
            }
            return OperationResult.SuccessedResult(true, Messages.RemoveAddToCart);
        }

        public async Task<OperationResult> DeleteAfterCheckoutAsync(int cartId)
        {
            var result = await _repository.DeleteAsync(cartId);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult();
        }

        public async Task<OperationResult> DeleteAsync(int cartId, long productId, int productNumber)
        {
            var result2 = await _repository.DeleteAsync(cartId);
            if (!result2.Success)
            {
                var error = result2.Exception!.ExceptionToErrorDTO(result2.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            var resultIncrease = await _productOrderDetailHelperService.IncreaseNumberAsync(productId, productNumber);
            if (!resultIncrease.Success)
            {
                return OperationResult.Failed(resultIncrease.Message!);
            }
            return OperationResult.SuccessedResult(true, Messages.RemoveAddToCart);
        }

        public async Task<OperationResult<List<FullCartItemDTO>>> GetByFarmerIdAsync(long farmerId)
        {
            var result = await _repository.SelectByFarmerIdAsync(farmerId);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resultError = await _errorService.LogErrorAsync(error);
                return OperationResult<List<FullCartItemDTO>>.Failed(resultError.Message!.ErrorMessage());
            }
            var data = result.Data.Where(x => x.Quantity > x.ProducNumber).ToList();
            foreach (var item in data)
            {
                var deleteResult = await DeleteAfterCheckoutAsync(item.Id);
                if (!deleteResult.Success)
                {
                    return OperationResult<List<FullCartItemDTO>>.Failed(deleteResult.Message!);
                }
            }
            result.Data.RemoveAll(x => x.Quantity > x.ProducNumber);
            return OperationResult<List<FullCartItemDTO>>.SuccessedResult(result.Data);
        }
    }
}
