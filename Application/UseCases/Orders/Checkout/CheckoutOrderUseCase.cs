using Application.Interfaces.Repositories;
using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.UseCases.CartItems.GetCartItem;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Orders.Checkout
{
    public class CheckoutOrderUseCase : ICheckoutOrderUseCase
    {
        private readonly ICartItemQueryService _cartItemQueryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IErrorRepository _errorRepository;
        public CheckoutOrderUseCase(
            ICartItemQueryService cartItemQueryService,
            IUnitOfWork unitOfWork,
            ICartItemRepository cartItemRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository,
            IMapper mapper,
            IErrorRepository errorRepository)
        {
            _cartItemQueryService = cartItemQueryService;
            _unitOfWork = unitOfWork;
            _cartItemRepository = cartItemRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _errorRepository = errorRepository;
        }
        public async Task<OperationResult> ExecuteAsync(long farmerId, CancellationToken token)
        {
            try
            {
                var cartItems = await _cartItemQueryService.SelectByFarmerIdAsync(farmerId, token);

                var data = cartItems.Where(x => x.Quantity > x.ProducNumber).ToList();
                foreach (var item in data)
                {
                    await _cartItemRepository.DeleteAsync(item.Id, token);
                }
                cartItems.RemoveAll(x => x.Quantity > x.ProducNumber);

                if (!cartItems.Any())
                {
                    return OperationResult.FailedResult(Messages.CartEmpty);
                }

                await _unitOfWork.BeginAsync();

                foreach (var item in cartItems)
                {
                    var checkOrder = await _orderRepository.CheckOrderAsync(farmerId, item.SellerId, token);
                    if (!checkOrder)
                    {
                        var order = _mapper.Map<Order>(item);
                        var resultOrder = await _orderRepository.InsertAsync(order, token);
                        item.OrderId = resultOrder;
                        var orderDetail = _mapper.Map<OrderDetail>(item);
                        await _orderDetailRepository.InsertAsync(orderDetail, token);

                        await _productRepository.IncreaseNumberAsync(item.ProductId, -item.Quantity, token);
                        await _cartItemRepository.DeleteAsync(item.Id, token);
                    }
                    else
                    {
                        var orderId = await _orderRepository.FindOrderByFarmerAndSellerAsync(farmerId, item.SellerId, token);
                        item.OrderId = orderId;
                        var order = _mapper.Map<OrderDetail>(item);
                        await _orderDetailRepository.InsertAsync(order, token);
                        await _cartItemRepository.DeleteAsync(item.Id, token);
                    }
                }
                await _unitOfWork.CommitAsync();
                return OperationResult.SuccessedResult(Messages.ShoppingSuccessful);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var erroeResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(erroeResult.ErrorMessage());
            }

        }
    }
}
