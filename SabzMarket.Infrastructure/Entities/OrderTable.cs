using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities
{
    public class OrderTable
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public virtual SellerTable? Seller { get; set; }
        public long FarmerId { get; set; }
        public virtual FarmerTable? Farmer { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
