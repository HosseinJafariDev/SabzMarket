using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Share.ViewModels
{
    public class GetProductOutputViewModel
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public long CategorieId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public string? ImageProduct { get; set; }
    }
}
