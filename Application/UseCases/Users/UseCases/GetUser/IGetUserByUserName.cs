using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Users.UseCases.GetUser
{
    public interface IGetUserByUserName
    {
        Task<OperationResult<GetUserByUserNameOutputDTO>> ExecuteAsync(string username);
    }
}
