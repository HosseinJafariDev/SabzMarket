using SabzMarket.Application.Common;
using SabzMarket.Application.Common.Dtos;
using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Constants.Order;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Domain.Enums;

namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public class GetNonPendingOrdersForSellerUseCase(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    : IGetNonPendingOrdersForSellerUseCase
{
    public async Task<PagedResult<GetOrdersForSellerOutputDto>> ExecuteAsync(long sellerId,
        SearchOrderFilterInputDto inputDto,
        CancellationToken token)
    {
        var orders = await orderRepository
            .GetOrderBySellerId(sellerId, inputDto.Search, inputDto.Price, inputDto.Number, inputDto.PageNumber,
                inputDto.PageSize, token, inputDto.Status);


        if (!orders.Items.Any())
            throw new NotFoundException(CommonMessages.NotFoundWarning(OrderMessages.Order));

        return new PagedResult<GetOrdersForSellerOutputDto>(ToDto(orders.Items), orders.TotalCount);
    }

    private static IReadOnlyList<GetOrdersForSellerOutputDto> ToDto(IReadOnlyList<Order> orders) =>
        orders.SelectMany(s => s.OrderDetails.Select(x =>
            new GetOrdersForSellerOutputDto(s.Id, x.Id, x.ProductId,
                x.Product!.ImageProduct, x.Status, x.Number, s.FarmerId, s.Farmer!.Address, s.Farmer.ProfileImage,
                s.Farmer.User!.FirstName, s.Farmer.User.LastName, s.Farmer.CodePosti))).ToList();
}