using SabzMarket.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Entities
{
    public class SmsOtpTable : BaseEntity
    {
        public long Otp { get; set; }
    }
}
