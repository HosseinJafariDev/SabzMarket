using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.AddToCart
{
    public interface IAddToCartUseCase
    {
        Task<OperationResult> ExecuteAsync(AddToCartInputDTO addToCartInputDTO, CancellationToken token);
    }
}
