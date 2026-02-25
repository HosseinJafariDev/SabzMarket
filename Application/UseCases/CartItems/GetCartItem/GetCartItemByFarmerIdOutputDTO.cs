using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.GetCartItem
{
    public class GetCartItemByFarmerIdOutputDTO
    {
        public int Id { get; set; }
        public long FarmerId { get; set; }
        public long SellerId { get; set; }
        public long ProductId { get; set; }
        public DateTime AddedDate { get; set; }
        public string? ProductImage { get; set; }
        public string? ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int ProducNumber { get; set; }
    }
}
