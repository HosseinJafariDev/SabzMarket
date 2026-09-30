namespace SabzMarket.API.Contracts.V1.Orders.GetOrders;

public record GetOrdersForSellerResponse(
    long OrderId,
    long OrderDetailId,
    long ProductId,
    string ImageProduct,
    string Status,
    int Number,
    long FarmerId,
    string Address,
    string FarmerProfileImage,
    string FirstName,
    string LastName,
    string CodePosti);