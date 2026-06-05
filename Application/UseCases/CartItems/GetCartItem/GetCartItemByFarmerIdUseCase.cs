using Application.Interfaces.Repositories;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.GetCartItem
{
    public class GetCartItemByFarmerIdUseCase : IGetCartItemByFarmerIdUseCase
    {
        private readonly IErrorRepository _errorRepository;
        private readonly ICartItemQueryService _cartItemQueryService;
        private readonly ICartItemRepository _cartItemRepository;
        public GetCartItemByFarmerIdUseCase(IErrorRepository errorRepository,
            ICartItemQueryService cartItemQueryService,
            ICartItemRepository cartItemRepository)
        {
            _errorRepository = errorRepository;
            _cartItemQueryService = cartItemQueryService;
            _cartItemRepository = cartItemRepository;
        }
        public async Task<OperationResult<List<GetCartItemByFarmerIdOutputDTO>>> ExecuteAsync(long farmerId, CancellationToken token)
        {
            try
            {
                var carts = await _cartItemQueryService.SelectByFarmerIdAsync(farmerId, token);
                var data = carts.Where(x => x.Quantity > x.ProducNumber).ToList();
                foreach (var item in data)
                {
                    await _cartItemRepository.DeleteAsync(item.Id, token);
                }
                carts.RemoveAll(x => x.Quantity > x.ProducNumber);

                return OperationResult<List<GetCartItemByFarmerIdOutputDTO>>.Success(carts, OperationError.Success);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<List<GetCartItemByFarmerIdOutputDTO>>.Failed(OperationError.ServerError, errorResult.ErrorMessage());
            }
        }
    }
}
