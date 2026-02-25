using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.DecreaseQuantity
{
    public interface IDecreaseQuantityUseCase
    {
        Task<OperationResult> ExecuteAsync(long productId, long farmerId);
    }
}
