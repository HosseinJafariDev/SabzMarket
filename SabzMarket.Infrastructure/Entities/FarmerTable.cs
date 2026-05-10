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
        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        [Required]
        public string? Address { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        [Required]
        public string? DataBuilt { get; set; }
        [Required]
        public int LandArea { get; set; }
        [Column(TypeName = "char")]
        [StringLength(10)]
        [Required]
        public string? NationalCode { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string? CodParvaneBHB { get; set; }
        [Column(TypeName = "nvarchar(max)")]

        [Required]
        public string? ProfileImage { get; set; }
        [Required]
        [Column(TypeName = "char(10)")]
        public string? CodePosti { get; set; }
        public virtual ICollection<OrderTable>? Orders { get; set; }
    }
}
