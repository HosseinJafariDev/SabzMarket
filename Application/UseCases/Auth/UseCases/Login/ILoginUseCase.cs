using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Auth.UseCases.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.UseCases.Login
{
    public interface ILoginUseCase
    {
        Task<OperationResult> ExecuteAsync(LoginInputDTO input);
    }
}
