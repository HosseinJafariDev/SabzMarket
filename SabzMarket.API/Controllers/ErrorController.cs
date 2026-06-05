using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.UseCases.Erorr;
using System.Buffers.Text;

namespace SabzMarket.API.Controllers
{
    public class ErrorController : BaseController
    {
        public readonly IAddLogErrorUseCase _addLogErrorUseCase;
        public ErrorController(IAddLogErrorUseCase addLogErrorUseCase)
        {
            _addLogErrorUseCase = addLogErrorUseCase;
        }
        [HttpPost]
        public async Task<ApiResult> LogErrorAsync([FromBody] ErrorLogDTO error)
        {
            var errorResult = await _addLogErrorUseCase.ExecuteAsync(error);
            return errorResult.OperationResultTOApiResult();
        }
    }
}
