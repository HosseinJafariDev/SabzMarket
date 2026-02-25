using SabzMarket.Application.UseCases.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.FeaturedSellers.GetFeaturedSeller
{
    public class GetAllFeaturedSellerOutputDTO
    {
        public long SellerId { get; set; }
        public long UserId { get; set; }
        public string? ProfileImage { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
