using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.FeaturedSellers.GetFeaturedSeller
{
    public interface IGetAllSellerUseCase
    {
        Task<OperationResult<List<GetAllFeaturedSellerOutputDTO>>> ExecuteAsync(CancellationToken token);
    }
}
