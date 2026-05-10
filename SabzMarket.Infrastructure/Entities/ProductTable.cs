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

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        public string? ProductName { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Number { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string? ImageProduct { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<OrderDetailTable>? OrderDetails { get; set; }
    }
}
