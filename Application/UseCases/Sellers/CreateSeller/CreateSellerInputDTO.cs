using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.CreateSeller
{
    public class CreateSellerInputDTO
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public string? WorkHistory { get; set; }

    }
}
