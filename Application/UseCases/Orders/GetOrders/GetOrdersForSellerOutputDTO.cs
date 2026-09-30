using SabzMarket.Domain.Enums;

namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public record GetOrdersForSellerOutputDto(
        long OrderId,
        long OrderDetailId,
        long ProductId,
        string ImageProduct,
        OrderStatus Status,
        int Number,
        long FarmerId,
        string Address,
        string FarmerProfileImage,
        string FirstName,
        string LastName,
        string CodePosti);