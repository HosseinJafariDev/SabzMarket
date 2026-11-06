using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Domain.Entities.SmsOtp;

public class SmsOtp : BaseEntity
{
    public long Otp { get; set; }

    private SmsOtp()
    {
    }

    public SmsOtp(long otp)
    {
        Otp = otp;
    }
}