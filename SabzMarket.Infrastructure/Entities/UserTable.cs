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
    public class UserTable : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public virtual SellerTable? Seller { get; set; }
        public virtual FarmerTable? Farmer { get; set; }
        public virtual ChatTable? Chat { get; set; }
    }
}
