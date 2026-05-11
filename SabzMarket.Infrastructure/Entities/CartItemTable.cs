using SabzMarket.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities
{
    public class CartItemTable : BaseEntity<int>
    {
        public long FarmerId { get; set; }
        public FarmerTable Farmer { get; set; }
        public long ProductId { get; set; }
        public ProductTable Product { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
