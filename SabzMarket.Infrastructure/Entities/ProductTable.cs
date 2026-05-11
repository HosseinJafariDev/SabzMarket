using SabzMarket.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities
{
    public class ProductTable : BaseEntity
    {
        public long SellerId { get; set; }
        public virtual SellerTable? Seller { get; set; }
        public long CategorieId { get; set; }
        public virtual CategorieTable? Categorie { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public string? ImageProduct { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<CartItemTable> CartItems { get; set; } = new List<CartItemTable>();
        public virtual ICollection<OrderDetailTable>? OrderDetails { get; set; }
    }
}
