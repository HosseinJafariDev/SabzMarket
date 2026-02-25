using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Erorr
{
    public interface IAddLogErrorUseCase
    {
        Task<OperationResult> ExecuteAsync(ErrorLogDTO errorLogDTO);
    }
}
