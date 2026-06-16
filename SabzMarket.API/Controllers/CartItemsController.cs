using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.CartItems.AddToCart;
using SabzMarket.Application.UseCases.CartItems.DecreaseQuantity;
using SabzMarket.Application.UseCases.CartItems.DeleteCartItem;
using SabzMarket.Application.UseCases.CartItems.GetCartItem;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace SabzMarket.API.Controllers
{
    [Authorize]
    public class CartItemsController : BaseController
    {
        private readonly IAddToCartUseCase _addToCartUseCase;
        private readonly IDecreaseQuantityUseCase _decreaseQuantityUseCase;
        private readonly IDeleteCartItemUseCase _deleteCartItemUseCase;
        private readonly IGetCartItemByFarmerIdUseCase _getCartItemByFarmerIdUseCase;

        public CartItemsController(
            IAddToCartUseCase addToCartUseCase,
            IDecreaseQuantityUseCase decreaseQuantityUseCase,
            IDeleteCartItemUseCase deleteCartItemUseCase,
            IGetCartItemByFarmerIdUseCase getCartItemByFarmerIdUseCase)
        {
            _addToCartUseCase = addToCartUseCase;
            _decreaseQuantityUseCase = decreaseQuantityUseCase;
            _deleteCartItemUseCase = deleteCartItemUseCase;
            _getCartItemByFarmerIdUseCase = getCartItemByFarmerIdUseCase;
        }

        [HttpPost]
        public async Task<ApiResult> AddToCart(AddToCartInputDTO addToCartInputDto, CancellationToken token)
        {
            var result = await _addToCartUseCase.ExecuteAsync(addToCartInputDto, token);
            return result.OperationResultTOApiResult();
        }

        [HttpPatch]
        public async Task<ApiResult> DecreaseQuantity(long productId, long farmerId, CancellationToken token)
        {
            var result = await _decreaseQuantityUseCase.ExecuteAsync(productId, farmerId, token);
            return result.OperationResultTOApiResult();
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int cartId, long productId, int productNumber, CancellationToken token)
        {
            var result = await _deleteCartItemUseCase.ExecuteAsync(cartId, productId, productNumber, token);
            return result.OperationResultTOApiResult();
        }

        [HttpGet("{farmerId:long}")]
        public async Task<ApiResult<List<GetCartItemByFarmerIdOutputDTO>>> GetByFarmerId(long farmerId,
            CancellationToken token)
        {
            var result = await _getCartItemByFarmerIdUseCase.ExecuteAsync(farmerId, token);
            return result.OperationResultTOApiResult();
        }
    }
}