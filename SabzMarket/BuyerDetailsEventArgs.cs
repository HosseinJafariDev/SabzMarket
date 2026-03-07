using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket
{
    public class BuyerDetailsEventArgs:EventArgs
    {
        public GetOrdersForSellerOutputViewModel? FarmerViewModel { get; set; }
    }
}
