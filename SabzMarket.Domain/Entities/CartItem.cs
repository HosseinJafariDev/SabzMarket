using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public long FarmerId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
