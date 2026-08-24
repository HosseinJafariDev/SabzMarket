using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Products;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Orders
{
    public class OrderDetail : BaseEntity
    {
        public long OrderId { get; private set; }
        public long ProductId { get; private set; }
        public int Price { get; private set; }
        public int Number { get; private set; }
        public string Status { get; set; } = nameof(OrderStatus.Pending);

        public Order? Order { get; private init; }
        public Product? Product { get; private init; }

        private OrderDetail()
        {
        }

        public OrderDetail(long orderId, long productId, int price, int number)
        {
            if (orderId <= 0)
                throw new DomainException(OrderMessages.OrderIdRequired);

            if (productId <= 0)
                throw new DomainException(OrderMessages.ProductIdRequired);

            if (price <= 0)
                throw new DomainException(OrderMessages.PriceRequired);

            if (number <= 0)
                throw new DomainException(OrderMessages.NumberRequired);

            Number = number;
            OrderId = orderId;
            ProductId = productId;
            Price = price;
        }
    }
}