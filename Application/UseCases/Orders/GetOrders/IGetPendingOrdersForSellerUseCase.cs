using SabzMarket.Application.Common.Dtos;

namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public interface IGetPendingOrdersForSellerUseCase
{
    Task<PagedResult<GetOrdersForSellerOutputDto>> ExecuteAsync(long sellerId,
        SearchOrderFilterInputDto inputInputDto, CancellationToken token);
}