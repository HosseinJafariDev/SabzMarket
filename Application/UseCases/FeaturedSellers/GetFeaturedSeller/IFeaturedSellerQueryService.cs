using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.FeaturedSellers.GetFeaturedSeller
{
    public interface IFeaturedSellerQueryService
    {
        Task<List<GetAllFeaturedSellerOutputDTO>> SelectAllSellerAsync();
    }
}
