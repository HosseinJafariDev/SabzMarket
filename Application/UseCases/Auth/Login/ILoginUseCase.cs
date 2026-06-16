using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.Login
{
    public interface ILoginUseCase
    {
        Task<OperationResult<string>> ExecuteAsync(LoginInputDTO input, CancellationToken token);
    }
}