using SabzMarket.Share.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Share.ViewModels
{
    public class LoginInputViewModel : BaseValidatoin
    {
        public long OtpId { get; set; }
        public long Otp { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
