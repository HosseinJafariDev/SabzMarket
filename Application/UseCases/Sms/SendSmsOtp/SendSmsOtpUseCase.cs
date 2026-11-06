using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using System.Security.Cryptography;
using SabzMarket.Application.Constants.Sms;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.SmsOtp;

namespace SabzMarket.Application.UseCases.Sms.SendSmsOtp;

public class SendSmsOtpUseCase(ISmsOtpRepository otpRepository, ISendSmsService sendSmsService, IUnitOfWork unitOfWork)
    : ISendSmsOtpUseCase
{
    public async Task<long> Execute(string phone, CancellationToken token)
    {
        var bytes = new byte[7];
        RandomNumberGenerator.Fill(bytes);

        var digits = bytes.Select(b => (b % 10).ToString());
        var newOtp = string.Concat(digits);

        var otp = new SmsOtp(long.Parse(newOtp));
        otpRepository.Add(otp);
        
        await unitOfWork.SaveChangesAsync(token);

        if (otp.Id == 0)
            throw new ConflictException(SmsMessages.SmsSendFailed);

        var result = await sendSmsService.SendSmsOtp(phone, newOtp, token);

        if (!result)
            throw new ConflictException(SmsMessages.SmsSendFailed);

        return otp.Id;
    }
}