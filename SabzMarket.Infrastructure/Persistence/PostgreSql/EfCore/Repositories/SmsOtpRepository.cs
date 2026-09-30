using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.SmsOtps;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories.Base;

namespace SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories;

public class SmsOtpRepository(SabzMarketDbContext context) : RepositoryBase<SmsOtp, long>(context), ISmsOtpRepository
{
    public async Task<bool> VerifyOtp(long id, long otp, CancellationToken token)
    {
        var result = await Context.smsOtps.AnyAsync(x => x.Id == id && x.Otp == otp, token);

        return result;
    }
}