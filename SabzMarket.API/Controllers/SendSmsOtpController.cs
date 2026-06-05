using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Sms.SendSmsOtp;

namespace SabzMarket.API.Controllers
{
    public class SendSmsOtpController : BaseController
    {
        private readonly ISendSmsOtpUseCase _sendSmsOtpUseCase;
        public SendSmsOtpController(ISendSmsOtpUseCase sendSmsOtpUseCase)
        {
            _sendSmsOtpUseCase = sendSmsOtpUseCase;
        }
        [HttpGet]
        public async Task<ApiResult<long>> Send(string Phone, CancellationToken token)
        {
            var result = await _sendSmsOtpUseCase.Execute(Phone, token);
            return result.OperationResultTOApiResult();
        }
    }
}
