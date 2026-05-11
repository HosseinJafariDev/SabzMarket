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
    public class FarmerTable : BaseEntity
    {
        public long UserId { get; set; }
        public virtual UserTable? User { get; set; }
        public string? Address { get; set; }
        public string? DataBuilt { get; set; }
        public int LandArea { get; set; }
        public string? NationalCode { get; set; }
        public string? CodParvaneBHB { get; set; }
        public string? ProfileImage { get; set; }
        public string? CodePosti { get; set; }

        public virtual ICollection<OrderTable>? Orders { get; set; }
        public virtual ICollection<CartItemTable>? CartItemTables { get; set; }
    }
}
