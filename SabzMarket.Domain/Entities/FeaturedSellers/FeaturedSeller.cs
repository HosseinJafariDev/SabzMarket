using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Sellers;

namespace SabzMarket.Domain.Entities.FeaturedSellers
{
    public class FeaturedSeller : BaseEntity<int>
    {
        public long SellerId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsActive { get; private set; } = true;

        public Seller? Seller { get; private init; }

        private FeaturedSeller()
        {
        }

        public FeaturedSeller(long sellerId, DateTime startDate, DateTime endDate)
        {
            if (sellerId <= 0)
            {
                throw new ArgumentException(FeaturedSellerMessages.SellerIdRequired);
            }

            if (startDate <= endDate)
            {
                throw new ArgumentException(FeaturedSellerMessages.InvalidDateRange);
            }

            SellerId = sellerId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Active() => IsActive = true;
        public void Inactive() => IsActive = false;
    }
}