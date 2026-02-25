using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.CartItems.AddToCart;
using SabzMarket.Application.UseCases.CartItems.DecreaseQuantity;
using SabzMarket.Application.UseCases.CartItems.DeleteCartItem;
using SabzMarket.Application.UseCases.CartItems.GetCartItem;

namespace SabzMarket.API.Controllers
{
    public class CartItemController : BaseController
    {
        private readonly IAddToCartUseCase _addToCartUseCase;
        private readonly IDecreaseQuantityUseCase _decreaseQuantityUseCase;
        private readonly IDeleteCartItemUseCase _deleteCartItemUseCase;
        private readonly IGetCartItemByFarmerIdUseCase _getCartItemByFarmerIdUseCase;
        public CartItemController(
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
        public async Task<OperationResult> AddToCartAsync(AddToCartInputDTO addToCartInputDTO)
        {
            var result = await _addToCartUseCase.ExecuteAsync(addToCartInputDTO);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult> DecreaseQuantityAsync(long productId, long farmerId)
        {
            var result = await _decreaseQuantityUseCase.ExecuteAsync(productId, farmerId);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult> DeleteAsync(int cartId, long productId, int productNumber)
        {
            var result = await _deleteCartItemUseCase.ExecuteAsync(cartId, productId, productNumber);
            return result;
        }
        [HttpGet]
        public Task<OperationResult<List<GetCartItemByFarmerIdOutputDTO>>> GetByFarmerIdAsync(long farmerId)
        {
            var result = _getCartItemByFarmerIdUseCase.ExecuteAsync(farmerId);
            return result;
        }
    }
}
