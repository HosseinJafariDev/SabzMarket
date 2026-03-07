using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket
{
    public class OrderDetailEventArgs: EventArgs
    {
        public OrderDetailEventArgs(GetOrdersForSellerOutputViewModel orderDTO, UC_Orders uC_Orders) 
        {
            this.orderDTO = orderDTO;
            C_Orders = uC_Orders;
        }
        public GetOrdersForSellerOutputViewModel orderDTO { get; set; }
        public UC_Orders C_Orders {  get; set; }
    }
}
