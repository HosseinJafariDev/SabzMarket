using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail
{
    public interface IMarkOrderDetailAsRejectedUseCase
    {
        Task<OperationResult> ExecuteAsync(long orderDetaileId, int number, int productId);
    }
}
