using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Erorr
{
    public class AddLogErrorUseCase : IAddLogErrorUseCase
    {
        private readonly IErrorRepository _errorRepository;
        public AddLogErrorUseCase(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }
        public async Task<OperationResult> ExecuteAsync(ErrorLogDTO errorLogDTO)
        {
            var errorResult = await _errorRepository.LogErrorAsync(errorLogDTO);
            return OperationResult.SuccessedResult(true, errorResult.ErrorMessage());
        }
    }
}
