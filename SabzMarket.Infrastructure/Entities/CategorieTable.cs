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
    public class CategorieTable : BaseEntity
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required]
        public string? Name { get; set; }
    }
}
