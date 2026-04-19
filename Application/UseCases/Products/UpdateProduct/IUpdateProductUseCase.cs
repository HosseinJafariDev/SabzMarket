using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.UpdateProduct
{
    public interface IUpdateProductUseCase
    {
        Task<OperationResult> ExecuteAsync(UpdateProductInputDTO updateProductInputDTO, Stream stream);
    }
}
