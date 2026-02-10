using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.GetProduct
{
    public class GetProductOutputDTO
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public long CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public string? ImageProduct { get; set; }
    }
}
