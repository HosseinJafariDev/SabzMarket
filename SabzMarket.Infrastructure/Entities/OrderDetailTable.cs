using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SabzMarket.Domain.Enums;
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
    public class OrderDetailTable : BaseEntity
    {
        public long OrderId { get; set; }
        public virtual OrderTable? Order { get; set; }
        public long ProductId { get; set; }
        public virtual ProductTable? Product { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Number { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        public string Status { get; set; } = OrderStatus.Pending.ToString();
    }
}
