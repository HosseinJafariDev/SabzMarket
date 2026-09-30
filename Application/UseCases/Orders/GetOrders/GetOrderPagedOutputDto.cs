namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public class GetOrderPagedOutputDto(IReadOnlyList<GetOrdersForSellerOutputDto> Items, int TotalCount)
{
}