using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.UserIsSeller
{
    public interface IUserIsSellerUseCase
    {
        Task<OperationResult<bool>> ExecuteAsync(string username, CancellationToken token);
    }
}
