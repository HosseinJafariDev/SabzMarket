using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Sms.Configuration
{
    public class VerifySendModel
    {
        public string Mobile { get; set; }

        public int TemplateId { get; set; }

        public VerifySendParameterModel[] Parameters { get; set; }
    }
}
