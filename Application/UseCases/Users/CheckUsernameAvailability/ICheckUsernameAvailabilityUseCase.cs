using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Users.CheckUsernameAvailability
{
    public interface ICheckUsernameAvailabilityUseCase
    {
        Task<OperationResult> ExecuteAsync(string username);
    }
}
