using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarketBuyer.UI
{
    public class ProductEventArgs<t>:EventArgs
    {
        public AddToCartInputViewModel CartItemDTO {  get; set; }
        public GetCartItemByFarmerIdOutputViewModel fullCartItemDTO { get; set; }
        public t uCProduct { get; set; }   
    }
}
