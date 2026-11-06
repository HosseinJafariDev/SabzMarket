using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Order;

public class OrderDetail : BaseEntity
{
    public long OrderId { get; private set; }
    public long ProductId { get; private set; }
    public int Price { get; private set; }
    public int Number { get; private set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public Entities.Order.Order? Order { get; private init; }
    public Product.Product? Product { get; private init; }

    private OrderDetail()
    {
    }

    public OrderDetail(long orderId, long productId, int price, int number)
    {
        if (orderId <= 0)
            throw new DomainException(OrderDomainMessages.OrderIdRequired);

        if (productId <= 0)
            throw new DomainException(OrderDomainMessages.ProductIdRequired);

        if (price <= 0)
            throw new DomainException(OrderDomainMessages.PriceRequired);

        if (number <= 0)
            throw new DomainException(OrderDomainMessages.NumberRequired);

        Number = number;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }
}