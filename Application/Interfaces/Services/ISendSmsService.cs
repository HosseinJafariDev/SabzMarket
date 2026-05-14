using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Services
{
    public interface ISendSmsService
    {
        Task<bool> SendSmsOtp(string Phone, string otp, CancellationToken token);
    }
}
