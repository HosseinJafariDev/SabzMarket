using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Entities.Log;

namespace SabzMarket.Application.UseCases.Erorr
{
    public class AddLogErrorUseCase(IExceptionLogRepository exceptionLogRepository) : IAddLogErrorUseCase
    {
        public async Task ExecuteAsync(ExceptionLog errorLogDTO)
        {
            await exceptionLogRepository.AddAsync(errorLogDTO);
        }
    }
}