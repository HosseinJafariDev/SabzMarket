using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.AddToCart
{
    public class AddToCartInputDTO
    {
        public long FarmerId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }= DateTime.Now;
    }
}
