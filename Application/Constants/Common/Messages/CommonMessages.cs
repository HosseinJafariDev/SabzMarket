namespace SabzMarket.Application.Constants.Common.Messages;

public static class CommonMessages
{
    public static string CreateSuccess(string param) => $"{param} با موفقیت ثبت شد";
    public static string EditSuccess(string param) => $"{param} با موفقیت ویرایش شد";
    public static string DeleteSuccess(string param) => $"{param} با موفقیت حذف شد";
    public static string DuplicateWarning(string param) => $"{param} وارد شده قبلا ثبت شده است !";
    public static string NotFoundWarning(string param) => $"{param} یافت نشد !";
    public static string InvalidWarning(string param) => $"{param} نامعتبر است !";
    public static string InvalidEntryWarning(string param) => $"{param} وارد شده نامعتبر است !";

    public static string NotAllowDeleteWarning(string param1, string param2) =>
        $"برای این {param1} {param2} ثبت شده است !";

    public static string TimeRangeOverlapping(string weekDay) =>
        $"برای روز {weekDay} در بازه زمانی انتخابی تداخل وجود دارد";

    public static string PleaseEnter(string param) => $"لطفا {param} را وارد نمایید";
    public static string PleaseSelect(string param) => $"لطفا {param} را انتخاب نمایید";

    public const string Url = "http";
    public const string Error = "مشکلی پیش امده لطفا با پشتیبانی تماس بگیرید";
}