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
    public class SellerTable : BaseEntity
    {
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserTable? User { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        [Required]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? ProfileImage { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(3)]
        [Required]
        public string? WorkHistory { get; set; }
        public virtual ICollection<OrderTable>? Orders { get; set; }
        public virtual ICollection<ProductTable>? Products { get; set; }
    }
}
