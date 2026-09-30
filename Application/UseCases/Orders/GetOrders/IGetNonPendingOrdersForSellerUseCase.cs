namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public interface IGetNonPendingOrdersForSellerUseCase
{
    Task<GetOrderPagedOutputDto> ExecuteAsync(long sellerId, SearchOrderFilterInputInputDto inputInputDto,
        CancellationToken token);
}