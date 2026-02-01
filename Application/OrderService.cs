using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Share;
using SabzMarket.Share.ErrorHandling;
using SabzMarket.Share.Mappers;
using SabzMarket.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IErrorService _errorService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductOrderDetailHelperService _productOrderDetailHelperService;
        public OrderService(
            IOrderRepository orderRepository,
            IErrorService errorService,
            ICartItemService cartItemService,
            IOrderDetailService orderDetail,
            IUnitOfWork unitOfWork,
            IProductOrderDetailHelperService productOrderDetailHelperService)
        {
            _errorService = errorService;
            _orderRepository = orderRepository;
            _cartItemService = cartItemService;
            _orderDetailService = orderDetail;
            _unitOfWork = unitOfWork;
            _productOrderDetailHelperService = productOrderDetailHelperService;
        }

        public async Task<OperationResult> CheckoutAsync(long farmerId)
        {
            await _unitOfWork.BeginAsync();
            var cart = await _cartItemService.GetByFarmerIdAsync(farmerId);
            if (!cart.Success)
            {
                return cart;
            }
            var cartItems = cart.Data;
            if (cartItems == null || cartItems.Count == 0)
                return OperationResult.Failed(Messages.CartEmpty);
            
            foreach (var item in cart.Data)
            {
                var checkOrder = await _orderRepository.CheckOrderAsync(farmerId, item.SellerId);
                if (!checkOrder.Success)
                {
                    if (!checkOrder.Result)
                    {
                        await _unitOfWork.RollbackAsync();
                        var error = checkOrder.Exception!.ExceptionToErrorDTO(checkOrder.Message!);
                        var resultError = await _errorService.LogErrorAsync(error);
                        return OperationResult.Failed(resultError.Message!.ErrorMessage());
                    }
                    var resultOrder = await _orderRepository.InsertAsync(item);
                    if (!resultOrder.Result)
                    {
                        await _unitOfWork.RollbackAsync();
                        var error = resultOrder.Exception!.ExceptionToErrorDTO(resultOrder.Message!);
                        var resultError = await _errorService.LogErrorAsync(error);
                        return OperationResult.Failed(resultError.Message!.ErrorMessage());
                    }
                    var resultOrderDetile = await _orderDetailService.InsertAsync(item, resultOrder.Data);
                    if (!resultOrderDetile.Success)
                    {
                        await _unitOfWork.RollbackAsync();
                        return resultOrderDetile;
                    }
                    var resultIncrease = await _productOrderDetailHelperService.IncreaseNumberAsync(item.ProductId, -item.Quantity);
                    if (!resultIncrease.Success)
                    {
                        await _unitOfWork.RollbackAsync();
                        return OperationResult.Failed(resultIncrease.Message!);
                    }
                    var deleteCart = await _cartItemService.DeleteAfterCheckoutAsync(item.Id);
                    if (!deleteCart.Success)
                    {
                        await _unitOfWork.RollbackAsync();
                        return deleteCart;
                    }
                }
                else
                {
                    var result = await _orderDetailService.InsertAsync(item, checkOrder.Data);
                    if (!result.Success)
                    {
                        await _unitOfWork.RollbackAsync();
                        return result;
                    }
                    var resultIncrease = await _productOrderDetailHelperService.IncreaseNumberAsync(item.ProductId, -item.Quantity);
                    if (!resultIncrease.Success)
                    {
                        await _unitOfWork.RollbackAsync();
                        return OperationResult.Failed(resultIncrease.Message!);
                    }
                    var deleteCart = await _cartItemService.DeleteAfterCheckoutAsync(item.Id);
                    if (!deleteCart.Success)
                    {
                        await _unitOfWork.RollbackAsync();
                        return deleteCart;
                    }
                }
            }
            await _unitOfWork.CommitAsync();
            return OperationResult.SuccessedResult(true, Messages.ShoppingSuccessful);

        }

        public async Task<OperationResult<List<OrderDTO>>> GetNonPendingOrdersForSellerAsync(long id, string search)
        {
            var result = await _orderRepository.SelectNonPendingOrdersForSellerAsync(id, search);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resultError = await _errorService.LogErrorAsync(error);
                return OperationResult<List<OrderDTO>>.Failed(resultError.Message!.ErrorMessage());
            }
            if (result.Data == null)
            {
                return OperationResult<List<OrderDTO>>.FailedResult(Messages.NullOrder);
            }
            return result;
        }

        public async Task<OperationResult<List<OrderDTO>>> GetPendingOrdersForSellerAsync(long id, string search)
        {
            var result = await _orderRepository.SelectPendingOrdersForSellerAsync(id, search);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resultError = await _errorService.LogErrorAsync(error);
                return OperationResult<List<OrderDTO>>.Failed(resultError.Message!.ErrorMessage());
            }
            if (result.Data == null)
            {
                return OperationResult<List<OrderDTO>>.FailedResult(Messages.NullOrder);
            }
            return result;
        }
    }
}
