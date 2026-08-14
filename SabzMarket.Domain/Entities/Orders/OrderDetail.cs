using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Orders
{
    public class OrderDetail
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public long Id { get; private set; }
        public long OrderId { get; private set; }
        public long ProductId { get; private set; }
        public int Price { get; private set; }
        public int Number { get; private set; }

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