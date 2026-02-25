using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Farmers.GetFarmer
{
    public interface IFarmerQueryService
    {
        Task<GetFarmerByUsernameOutputDTO> SelectByUsernameAsync(string username);
    }
}
