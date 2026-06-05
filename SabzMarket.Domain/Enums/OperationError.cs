using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Enums
{
    public enum OperationError
    {
        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success,

        [Display(Name = "عملیات با موفقیت انجام شد با متن دلخواه")]
        None,

        [Display(Name = "خطایی در سرور رخ داده است")]
        ServerError,

        [Display(Name = "یافت نشد")]
        NotFound,

        [Display(Name = "اطلاعات معتبر نمی باشد")]
        Validation,

        [Display(Name = "عملیات نمی‌تواند انجام شود چون با یک وضعیت موجود در سیستم در تضاد است")]
        Conflict,

        [Display(Name = "خطای سطح دسرسی")]
        Forbidden,

        [Display(Name = "خطای احراز هویت")]
        Unauthorized,
    }
}
