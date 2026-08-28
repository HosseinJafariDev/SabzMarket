using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SabzMarket.Infrastructure.Sms.Configuration
{
    public class SmsOutput
    {
        public int status { get; set; }
        public string message { get; set; }
        public SmsData data { get; set; }
    }
}
