using Application.Interfaces.Repositories;
using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.AddToCart
{
    public class AddToCartUseCase : IAddToCartUseCase
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public AddToCartUseCase(ICartItemRepository cartItemRepository,
            IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> ExecuteAsync(AddToCartInputDTO addToCartInputDTO, CancellationToken token)
        {
            var existProduct = await _cartItemRepository
                .ExistProductAsync(addToCartInputDTO.FarmerId, addToCartInputDTO.ProductId, token);

            if (existProduct)
            {
                await _cartItemRepository
                    .ChangeQuantityAsync(
                        addToCartInputDTO.ProductId,
                        addToCartInputDTO.FarmerId,
                        addToCartInputDTO.Quantity,
                        token);

                return OperationResult.Success(OperationError.None, Messages.SuccessAddToCart);
            }

            var cartItem = _mapper.Map<CartItem>(addToCartInputDTO);

            await _cartItemRepository.InsertAsync(cartItem, token);

            return OperationResult.Success(OperationError.None, Messages.SuccessAddToCart);
        }
    }
}