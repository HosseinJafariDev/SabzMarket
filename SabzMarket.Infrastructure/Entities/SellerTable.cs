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
        public virtual UserTable? User { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public string? WorkHistory { get; set; }

        public virtual ICollection<OrderTable>? Orders { get; set; }
        public virtual ICollection<ProductTable>? Products { get; set; }
        public virtual ICollection<FeaturedSellerTable>? FeaturedSellerTables { get; set; }
    }
}
