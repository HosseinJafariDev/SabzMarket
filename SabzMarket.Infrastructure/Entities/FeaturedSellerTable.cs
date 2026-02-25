using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities
{
    public class FeaturedSellerTable
    {
        public int Id { get; set; }
        public long SellerId {  get; set; }
        public virtual SellerTable? Seller { get; set; }
        //UTC Time
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
