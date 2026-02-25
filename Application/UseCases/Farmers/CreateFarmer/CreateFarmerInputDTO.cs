using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Farmers.CreateFarmer
{
    public class CreateFarmerInputDTO
    {
        public string? Address { get; set; }
        public string? DataBuilt { get; set; }
        public int LandArea { get; set; }
        public string? NationalCode { get; set; }
        public string? CodParvaneBHB { get; set; }
        public string? ProfileImage { get; set; }
        public string? CodePosti { get; set; }
    }
}
