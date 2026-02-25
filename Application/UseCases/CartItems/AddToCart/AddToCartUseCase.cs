using Application.Interfaces.Repositories;
using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
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
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        public AddToCartUseCase(ICartItemRepository cartItemRepository, IErrorRepository errorRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _errorRepository = errorRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult> ExecuteAsync(AddToCartInputDTO addToCartInputDTO)
        {
            try
            {
                var existProduct = await _cartItemRepository
               .ExistProductAsync(addToCartInputDTO.FarmerId, addToCartInputDTO.ProductId);

                if (existProduct)
                {
                    await _cartItemRepository
                        .ChangeQuantityAsync(addToCartInputDTO.ProductId, addToCartInputDTO.FarmerId, 1);
                }
                var cartItem = _mapper.Map<CartItem>(addToCartInputDTO);


                await _cartItemRepository.InsertAsync(cartItem);
                return OperationResult.SuccessedResult(true, Messages.SuccessAddToCart);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
