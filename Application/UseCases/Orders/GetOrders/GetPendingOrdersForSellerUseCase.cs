using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;

namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public class GetPendingOrdersForSellerUseCase(IOrderRepository orderRepository) : IGetPendingOrdersForSellerUseCase
{
    public async Task<GetOrderPagedOutputDto> ExecuteAsync(long sellerId, string search,
        CancellationToken token)
    {
        var orders = await orderRepository.SelectPendingOrdersForSellerAsync(sellerId, search, token);
        if (!orders.Any())
            throw new NotFoundException(Messages.NotFoundPendingOrders);

        return OperationResult<List<GetOrdersForSellerOutputDTO>>
            .Success(orders, OperationError.Success);
    }
}