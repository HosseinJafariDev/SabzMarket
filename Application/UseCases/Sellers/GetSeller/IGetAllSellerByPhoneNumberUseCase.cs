using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.GetSeller
{
    public interface IGetAllSellerByPhoneNumberUseCase
    {
        Task<OperationResult<List<GetSellerOutputDTO>>> ExecuteAsync(string phone, CancellationToken token);
    }
}
