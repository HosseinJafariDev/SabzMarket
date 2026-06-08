using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Application.UseCases.Sms.SendSmsOtp
{
    public class SendSmsOtpUseCase : ISendSmsOtpUseCase
    {
        private readonly ISmsOtpRepository _smsOtpRepository;
        private readonly ISendSmsService _smsService;

        public SendSmsOtpUseCase(ISmsOtpRepository smsOtpRepository, ISendSmsService sendSmsService)
        {
            _smsOtpRepository = smsOtpRepository;
            _smsService = sendSmsService;
        }

        public async Task<OperationResult<long>> Execute(string Phone, CancellationToken token)
        {
            var bytes = new byte[7];
            RandomNumberGenerator.Fill(bytes);

            var digits = bytes.Select(b => (b % 10).ToString());
            var otp = string.Concat(digits);

            var otpId = await _smsOtpRepository.Insert(long.Parse(otp), token);
            if (otpId == 0)
                throw new ConflictException(Messages.Error);

            var result = await _smsService.SendSmsOtp(Phone, otp, token);
            if (!result)
                throw new ConflictException(Messages.Error);

            return OperationResult<long>.Success(otpId, OperationError.None, "کد ورود ارسال شد");
        }
    }
}