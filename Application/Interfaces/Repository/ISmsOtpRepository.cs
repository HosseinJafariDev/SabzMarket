using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.SmsOtps;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ISmsOtpRepository : IRepository<SmsOtp, long>
    {
    }
}