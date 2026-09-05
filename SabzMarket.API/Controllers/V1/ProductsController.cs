using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Products.CreateProduct;
using SabzMarket.Application.UseCases.Products.DeleteProduct;
using SabzMarket.Application.UseCases.Products.GetProduct;
using SabzMarket.Application.UseCases.Products.UpdateProduct;

namespace SabzMarket.API.Controllers.V1
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly IGetProductBySellerIdUseCase _getProductBySellerIdUseCase;
        private readonly IGetProductByNameUseCase _getProductByNameUseCase;
        private readonly IUpdateProductUseCase _updateProductUseCase;
        private readonly IDeleteProductUseCase _deleteProductUseCase;

        public ProductsController(
            ICreateProductUseCase createProductUseCase,
            IGetProductBySellerIdUseCase getProductBySellerIdUseCase,
            IGetProductByNameUseCase getProductByNameUseCase,
            IUpdateProductUseCase updateProductUseCase,
            IDeleteProductUseCase deleteProductUseCase)
        {
            _createProductUseCase = createProductUseCase;
            _getProductBySellerIdUseCase = getProductBySellerIdUseCase;
            _getProductByNameUseCase = getProductByNameUseCase;
            _updateProductUseCase = updateProductUseCase;
            _deleteProductUseCase = deleteProductUseCase;
        }

        [HttpPost]
        public async Task<ApiResult> CreateProduct([FromForm] CreateProductInputDTO product, IFormFile file,
            CancellationToken token)
        {
            Stream stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }

            var result = await _createProductUseCase.ExecuteAsync(product, stream, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet("seller/{sellerId:long}")]
        public async Task<ApiResult<List<GetProductOutputDTO>>> GetProductsBySeller(long sellerId,
            CancellationToken token)
        {
            var result = await _getProductBySellerIdUseCase.ExecuteAsync(sellerId, token);
            return result.OperationResultTOApiResult();
        }

        [HttpDelete("{id:long}")]
        public async Task<ApiResult> Delete(long id, CancellationToken token)
        {
            var result = await _deleteProductUseCase.ExecuteAsync(id, token);
            return result.OperationResultTOApiResult();
        }

        [HttpPut]
        public async Task<ApiResult> Update([FromForm] UpdateProductInputDTO product, IFormFile file,
            CancellationToken token)
        {
            Stream stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }

            var result = await _updateProductUseCase.ExecuteAsync(product, stream, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet("name/{search}")]
        public async Task<ApiResult<List<GetProductOutputDTO>>> GetByName(string search, CancellationToken token)
        {
            var result = await _getProductByNameUseCase.ExecuteAsync(search, token);
            return result.OperationResultTOApiResult();
        }
    }
}