using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.SignUp
{
    public interface ISignUpUseCase
    {
        Task<OperationResult> ExecuteAsync(SignUpInputDTO input, CancellationToken token);
    }
}
