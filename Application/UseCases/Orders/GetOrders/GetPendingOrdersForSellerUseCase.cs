using SabzMarket.Application.Common;
using SabzMarket.Application.Common.Dtos;
using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Constants.Order;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Orders;

namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public class GetPendingOrdersForSellerUseCase(IOrderRepository orderRepository) : IGetPendingOrdersForSellerUseCase
{
    public async Task<PagedResult<GetOrdersForSellerOutputDto>> ExecuteAsync(long sellerId,
        SearchOrderFilterInputDto inputDto,
        CancellationToken token)
    {
        var orders = await orderRepository.GetOrderBySellerId(sellerId, inputDto.Search, inputDto.Price,
            inputDto.Number, inputDto.PageNumber, inputDto.PageSize, token);

        if (!orders.Items.Any())
            throw new NotFoundException(CommonMessages.NotFoundWarning(OrderMessages.Order));

        return new PagedResult<GetOrdersForSellerOutputDto>(ToDto(orders.Items), orders.TotalCount);
    }

    private IReadOnlyList<GetOrdersForSellerOutputDto> ToDto(IReadOnlyList<Order> orders) =>
        orders.SelectMany(x =>
            x.OrderDetails.Select(d =>
                new GetOrdersForSellerOutputDto(x.Id, d.Id, d.ProductId, d.Product!.ImageProduct, d.Status, d.Number,
                    x.FarmerId, x.Farmer!.Address, x.Farmer.ProfileImage, x.Farmer!.User!.FirstName,
                    x.Farmer.User.LastName, x.Farmer.CodePosti))).ToList();
}