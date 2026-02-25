using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.DeleteCartItem
{
    public interface IDeleteCartItemUseCase
    {
        Task<OperationResult> ExecuteAsync(int cartId, long productId, int productNumber);
    }
}
