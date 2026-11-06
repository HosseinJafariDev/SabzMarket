using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Order;

public class Order : BaseEntity
{
    public long SellerId { get; private set; }
    public long FarmerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    private readonly List<OrderDetail> _orderDetails = [];  

    public Seller.Seller? Seller { get; private init; }
    public Buyer.Buyer? Farmer { get; private init; }
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