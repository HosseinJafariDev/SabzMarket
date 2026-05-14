using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.CreateProduct
{
    public interface ICreateProductUseCase
    {
        Task<OperationResult> ExecuteAsync(CreateProductInputDTO createProductInputDTO, Stream stream, CancellationToken token);
    }
}
