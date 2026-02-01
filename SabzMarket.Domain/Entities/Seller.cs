using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Entities
{
    public class Seller
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public string? WorkHistory { get; set; }
    }
}
