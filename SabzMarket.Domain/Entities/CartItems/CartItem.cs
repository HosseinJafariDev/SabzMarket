using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Farmers;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Domain.Entities.CartItems
{
    public class CartItem : BaseEntity<int>
    {
        public long FarmerId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }

        public Farmer? Farmer { get; private init; }
        public Product? Product { get; private init; }
    }
}