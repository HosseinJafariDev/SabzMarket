using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Share;
using SabzMarket.Share.ErrorHandling;
using SabzMarket.Share.Mappers;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application
{
    public class ProductService : IProductService
    {
        private readonly IErrorService _errorService;
        private readonly IProductRepository _productRepository;
        private readonly IProductOrderDetailHelperService _productOrderDetailHelperService;
        public ProductService(IErrorService errorService, IProductRepository productRepository, IProductOrderDetailHelperService productOrderDetailHelperService)
        {
            _errorService = errorService;
            _productRepository = productRepository;
            _productOrderDetailHelperService = productOrderDetailHelperService;
        }

        public async Task<OperationResult> CreateProductAsync(ProductViewModel product)
        {
            if (!product.IsValid)
                return OperationResult.FailedResult(product.ErrorMessage);
            using var savePhoto = new SavePhoto();
            var result2 = await savePhoto.SaveAsync(product.ImageProduct!);

            if (!result2.Success)
            {
                var error = result2.Exception!.ExceptionToErrorDTO(result2.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result1.Message!.ErrorMessage());
            }

            product.ImageProduct = result2.Message!;
            ProductDTO productDTO = product.ToProductDTO();
            var result = await _productRepository.InsertAsync(productDTO);

            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result1.Message!.ErrorMessage());
            }

            return OperationResult.SuccessedResult(true, Messages.ProductAdded);


        }

        public async Task<OperationResult> DeleteAsync(long id)
        {
            var result1 = await _productOrderDetailHelperService.HasPendingOrdersForProductAsync(id);
            if (!result1.Success)
            {
                if (!result1.Result)
                {
                    return result1;
                }
                var result = await _productRepository.DeleteAsync(id);
                if (!result.Success)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var errorResult = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(errorResult.Message!.ErrorMessage());
                }
                return OperationResult.SuccessedResult(true, Messages.DeleteProduct);
            }
            return OperationResult.FailedResult(Messages.ProductHasUnsentOrders);
        }

        public async Task<OperationResult<List<ProductDTO>>> GetByNameAsync(string search)
        {
            var result = await _productRepository.SelectByNameAsync(search);
            if (!result.Success)
            {
                var erroe = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult=await _errorService.LogErrorAsync(erroe);
                return OperationResult<List<ProductDTO>>.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult<List<ProductDTO>>.SuccessedResult(result.Data);
        }

        public async Task<OperationResult<List<ProductDTO>>> GetProductsBySellerAsync(long sellerId)
        {
            var result = await _productRepository.GetAllBySellerAsync(sellerId);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resulterror = await _errorService.LogErrorAsync(error);
                return OperationResult<List<ProductDTO>>.Failed(resulterror.Message!.ErrorMessage());
            }
            return result;
        }

        public async Task<OperationResult> UpdateAsync(ProductViewModel product)
        {
            if (!product.IsValid)
                return OperationResult.FailedResult(product.ErrorMessage);
            if (product.ImageProduct!.Contains(Messages.Url))
            {
                var resultUpdate = await _productRepository.UpdateAsync(product.ToProductDTO());
                if (!resultUpdate.Success)
                {
                        var error = resultUpdate.Exception!.ExceptionToErrorDTO(resultUpdate.Message!);
                        var eroorResult=await _errorService.LogErrorAsync(error);
                        return eroorResult;
                }
                return OperationResult.SuccessedResult(true, Messages.update);
            }
            using var savePhoto = new SavePhoto();
            var resultSavePhoto = await savePhoto.SaveAsync(product.ImageProduct);
            if (!resultSavePhoto.Success)
            {
                var error=resultSavePhoto.Exception!.ExceptionToErrorDTO(resultSavePhoto.Message!);
                var result=await _errorService.LogErrorAsync(error);
                return result;
            }
            product.ImageProduct = resultSavePhoto.Message;
            var resultUpdate1=await _productRepository.UpdateAsync(product.ToProductDTO());
            if (!resultUpdate1.Success)
            {
                var error = resultUpdate1.Exception!.ExceptionToErrorDTO(resultUpdate1.Message!);
                var eroorResult = await _errorService.LogErrorAsync(error);
                return eroorResult;
            }
            return OperationResult.SuccessedResult(true, Messages.update);
        }
    }
}
