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
    public class Order
    {
        public long Id { get; private set; }
        public long SellerId { get; private set; }
        public long FarmerId { get; private set; }
        public DateTime OrderDate { get; private set; }

        private Order()
        {
        }

        public Order(long sellerId, long farmerId)
        {
            if (sellerId <= 0)
                throw new DomainException(OrderMessages.SellerIdRequired);

            if (farmerId <= 0)
                throw new DomainException(OrderMessages.FarmerIdRequired);

            SellerId = sellerId;
            FarmerId = farmerId;
            OrderDate = DateTime.Now;
        }
    }
}