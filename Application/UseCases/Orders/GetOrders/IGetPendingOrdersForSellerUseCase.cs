namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public interface IGetPendingOrdersForSellerUseCase
{
    Task<GetOrderPagedOutputDto> ExecuteAsync(long sellerId,
        SearchOrderFilterInputInputDto inputInputDto, CancellationToken token);
}