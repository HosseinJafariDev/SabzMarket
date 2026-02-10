using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.GetProduct
{
    public interface IGetProductByNameUseCase
    {
        Task<OperationResult<List<GetProductOutputDTO>>> ExecuteAsync(string name);
    }
}
