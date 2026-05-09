using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "ارسال شد")]
        Sent,
        [Display(Name = "رد شده")]
        Rejected,
        [Display(Name = "درحال پردازش")]
        Pending
    }
}
