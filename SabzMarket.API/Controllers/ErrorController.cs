using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.UseCases.Erorr;
using Microsoft.AspNetCore.Authorization;
using SabzMarket.Domain.Entities.Log;

namespace SabzMarket.API.Controllers
{
    [Authorize]
    public class ErrorController : BaseController
    {
        public readonly IAddLogErrorUseCase _addLogErrorUseCase;

        public ErrorController(IAddLogErrorUseCase addLogErrorUseCase)
        {
            _addLogErrorUseCase = addLogErrorUseCase;
        }

        [HttpPost]
        public async Task<ApiResult> LogErrorAsync([FromBody] ExceptionLog exceptionLog)
        {
            await _addLogErrorUseCase.ExecuteAsync(exceptionLog);
            return Ok();
        }
    }
}