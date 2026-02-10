using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.DeleteProduct
{
    public interface IDeleteProductUseCase
    {
        Task<OperationResult> ExecuteAsync(long id);
    }
}
