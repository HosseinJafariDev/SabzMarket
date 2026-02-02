using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Auth.UseCases.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Users.UseCases.CheckUsernameAvailability
{
    public interface ICheckUsernameAvailabilityUseCase
    {
        Task<OperationResult> ExecuteAsync(string username);
    }
}
