using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.UpdateSeller
{
    public class SellerUpdateInputDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CurrentUsername { get; set; }
        public string? NewUsername { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public string? WorkHistory { get; set; }
    }
}
