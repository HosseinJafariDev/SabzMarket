using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sms.SendSmsOtp
{
    public class SendSmsOtpUseCase : ISendSmsOtpUseCase
    {
        private readonly ISmsOtpRepository _smsOtpRepository;
        private readonly ISendSmsService _smsService;
        private readonly IErrorRepository _errorRepository;
        public SendSmsOtpUseCase(ISmsOtpRepository smsOtpRepository, ISendSmsService sendSmsService, IErrorRepository errorRepository)
        {
            _smsOtpRepository = smsOtpRepository;
            _errorRepository = errorRepository;
            _smsService = sendSmsService;
        }
        public async Task<OperationResult<long>> Execute(string Phone)
        {
            try
            {
                Random random = new Random();
                var number1 = random.Next(1, 9);
                var number2 = random.Next(10, 99);
                var number3 = random.Next(10, 99);
                var number4 = random.Next(10, 99);
                var otp = $"{number1}{number2}{number3}{number4}";

                var otpId = await _smsOtpRepository.Insert(long.Parse(otp));
                if (otpId == 0)
                {
                    return OperationResult<long>.FailedResult(Messages.Error);
                }

                var result = await _smsService.SendSmsOtp(Phone, otp);
                if (!result)
                {
                    return OperationResult<long>.FailedResult(Messages.Error);
                }

                return OperationResult<long>.SuccessedResult(otpId, "کد ورود ارسال شد");
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<long>.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
