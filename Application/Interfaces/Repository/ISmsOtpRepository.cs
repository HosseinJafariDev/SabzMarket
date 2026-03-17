using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ISmsOtpRepository
    {
        Task<long> Insert(long Otp);
        Task<bool> VerifyOtp(long id, long otp);
    }
}
