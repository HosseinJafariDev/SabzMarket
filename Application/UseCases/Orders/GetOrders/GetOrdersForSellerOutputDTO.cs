using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Orders.GetOrders
{
    public class GetOrdersForSellerOutputDTO
    {
        public long OrderId { get; set; }
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string? ImageProduct { get; set; }
        public string? ProductName { get; set; }
        public string? Status { get; set; }
        public int Number { get; set; }
        public long FarmerId { get; set; }
        public string? Address { get; set; }
        public string? FarmerProfileImage { get; set; }
        public string? Phone { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CodePosti { get; set; }
    }
}
