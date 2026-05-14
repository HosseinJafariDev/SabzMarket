using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Orders.Checkout
{
    public interface ICheckoutOrderUseCase
    {
        Task<OperationResult> ExecuteAsync(long farmerId, CancellationToken token);
    }
}
