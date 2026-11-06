using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.SmsOtp;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ISmsOtpRepository : IRepository<SmsOtp, long>
    {
        public Task<bool> VerifyOtp(long id, long otp, CancellationToken token);
    }
}