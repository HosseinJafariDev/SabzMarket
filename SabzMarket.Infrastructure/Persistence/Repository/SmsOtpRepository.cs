using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class SmsOtpRepository : ISmsOtpRepository
    {
        private readonly SabzMarketDbContext _Context;
        public SmsOtpRepository(SabzMarketDbContext context)
        {
            _Context = context;
        }
        public async Task<long> Insert(long Otp, CancellationToken token)
        {
            SmsOtpTable table = new SmsOtpTable()
            {
                Otp = Otp
            };

            _Context.smsOtps.Add(table);
            await _Context.SaveChangesAsync();

            return table.Id;
        }
        public async Task<bool> VerifyOtp(long id, long otp)
        {
            var result = await _Context.smsOtps.AnyAsync(X => X.Id == id && X.Otp == otp);

            return result;
        }
    }
}
