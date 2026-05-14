using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.GetSeller
{
    public interface IGetSellerByIdUseCase
    {
        Task<OperationResult<GetSellerOutputDTO>> ExecuteAsync(long id, CancellationToken token);
    }
}
