using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Farmers;
using SabzMarket.Domain.Entities.Sellers;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Orders;

public class Order : BaseEntity
{
    public long SellerId { get; private set; }
    public long FarmerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    private readonly List<OrderDetail> _orderDetails = [];  

    public Seller? Seller { get; private init; }
    public Buyer? Farmer { get; private init; }
    public ICollection<OrderDetail> OrderDetails => _orderDetails.AsReadOnly();

    private Order()
    {
    }

    public Order(long sellerId, long farmerId)
    {
        if (sellerId <= 0)
            throw new DomainException(OrderDomainMessages.SellerIdRequired);

        if (farmerId <= 0)
            throw new DomainException(OrderDomainMessages.FarmerIdRequired);

        SellerId = sellerId;
        FarmerId = farmerId;
        OrderDate = DateTime.Now;
    }
}