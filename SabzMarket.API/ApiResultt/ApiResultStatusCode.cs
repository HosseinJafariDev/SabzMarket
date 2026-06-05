using System.ComponentModel.DataAnnotations;

namespace SabzMarket.API.ApiResultt
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success = 200,

        [Display(Name = "خطایی در سرور رخ داده است")]
        ServerError = 500,

        [Display(Name = "یافت نشد")]
        NotFound = 404,

        [Display(Name = "اطلاعات معتبر نمی باشد")]
        BadRequest = 400,

        [Display(Name = "عملیات نمی‌تواند انجام شود چون با یک وضعیت موجود در سیستم در تضاد است")]
        Conflict = 409,

        [Display(Name = "خطای سطح دسرسی")]
        Forbidden = 403,

        [Display(Name = "خطای احراز هویت")]
        UnAuthorized = 401,
    }
}
