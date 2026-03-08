using Microsoft.AspNetCore.Mvc;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Products.CreateProduct;
using SabzMarket.Application.UseCases.Products.DeleteProduct;
using SabzMarket.Application.UseCases.Products.GetProduct;
using SabzMarket.Application.UseCases.Products.UpdateProduct;

namespace SabzMarket.API.Controllers
{
    public class ProductController : BaseController
    {
        public readonly ICreateProductUseCase _createProductUseCase;
        private readonly IGetProductBySellerIdUseCase _getProductBySellerIdUseCase;
        private readonly IGetProductByNameUseCase _getProductByNameUseCase;
        private readonly IUpdateProductUseCase _updateProductUseCase;
        private readonly IDeleteProductUseCase _deleteProductUseCase;
        public ProductController(
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
        public async Task<OperationResult> CreateProductAsync([FromBody] CreateProductInputDTO product)
        {
            var result = await _createProductUseCase.ExecuteAsync(product);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult<List<GetProductOutputDTO>>> GetProductsBySellerAsync(long sellerId)
            {
            var result = await _getProductBySellerIdUseCase.ExecuteAsync(sellerId);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult> DeleteAsync(long id)
        {
            var result = await _deleteProductUseCase.ExecuteAsync(id);
            return result;
        }
        [HttpPost]
        public async Task<OperationResult> UpdateAsync([FromBody] UpdateProductInputDTO product)
        {
            var result = await _updateProductUseCase.ExecuteAsync(product);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult<List<GetProductOutputDTO>>> GetByNameAsync(string search)
        {
            var result = await _getProductByNameUseCase.ExecuteAsync(search);
            return result;
        }
    }
}

