using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.GetProduct
{
    public interface IGetProductBySellerIdUseCase
    {
        Task<OperationResult<List<GetProductOutputDTO>>> ExecuteAsync(long sellerId, CancellationToken token);
    }
}
