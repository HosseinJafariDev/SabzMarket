using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket
{
    public class ProductEventArgs:EventArgs
    {
        public ProductEventArgs(GetProductOutputViewModel product)
        {
            Product = product;
        }
       public GetProductOutputViewModel Product { get; set; }
    }
}
