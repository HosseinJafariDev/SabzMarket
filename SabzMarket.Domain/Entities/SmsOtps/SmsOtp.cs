using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Domain.Entities.SmsOtps;

public class SmsOtp : BaseEntity
{
    public long Otp { get; set; }
}