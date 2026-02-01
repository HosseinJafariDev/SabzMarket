using Application.Interfaces.Services;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.BLL
{
    public class ErrorService : IErrorService
    {
        public readonly IErrorRepository _errorRepository;
        public ErrorService(IErrorRepository errorRepository) 
        {
            _errorRepository = errorRepository;
        }
        public async Task<OperationResult> LogErrorAsync(Exception ex, String layer)
        {
           var result= await _errorRepository.LogErrorAsync(ex,layer);
            return OperationResult.SuccessedResult(true,result);
        }
    }
}
