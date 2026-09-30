using SabzMarket.Application.Common;
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
    public async Task<GetOrderPagedOutputDto> ExecuteAsync(long sellerId, SearchOrderFilterInputInputDto inputInputDto,
        CancellationToken token)
    {
        var orders = await orderRepository
            .GetWithPaginationAsync(token,
                x => x.OrderDetails.Any(s => s.Status != OrderStatus.Pending) && x.SellerId == sellerId,
                filter: inputInputDto,
                skip: inputInputDto.Skip,
                take: inputInputDto.Take);


        if (!orders.Items.Any())
            throw new NotFoundException(CommonMessages.NotFoundWarning(OrderMessages.Order));

        return new GetOrderPagedOutputDto(ToDto(orders.Items), orders.TotalCount);
    }

    private static IReadOnlyList<GetOrdersForSellerOutputDto> ToDto(IReadOnlyList<Order> orders) =>
        orders.SelectMany(s => s.OrderDetails.Select(x =>
            new GetOrdersForSellerOutputDto(s.Id, x.Id, x.ProductId,
                x.Product!.ImageProduct, x.Status, x.Number, s.FarmerId, s.Farmer!.Address, s.Farmer.ProfileImage,
                s.Farmer.User!.FirstName, s.Farmer.User.LastName, s.Farmer.CodePosti))).ToList();
}