using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Common
{
    public static class Messages
    {
        public const string FirstNameMaxLength = "نام باید حداکثر 50 کاراکتر باشد";
        public const string FirstNameMinLength = "نام باید حداقل 3 کاراکتر باشد";
        public const string LastNameMaxLength = "نام خانوادگی باید حداکثر 50 کاراکتر باشد";
        public const string LastNameMinLength = "نام خانوادگی باید حداقل 2 کاراکتر باشد";
        public const string PhoneInvalid = "شماره تلفن معتبر نمی باشد";
        public const string PhoneRequired = "شماره تلفن الزامی است";
        public const string UserNameRequired = "لطفا نام کاربری برای خود انتخاب کنید";
        public const string UserNameMinLength = "نام کاربری حداقل 6 کاراکتر باشد";
        public const string UsernameNotFarsi = "نام کاربری نباید شامل حروف فارسی باشد";
        public const string Password1Required = "لطفا رمز عبوری برای خود انتخاب کنید";
        public const string Password1Powerful = "لطفا رمز عبوری قوی انتخاب کنید ";
        public const string Password2Required = "تکرار رمز عبور الزامی است";
        public const string PasswordsDoNotMatch = "تکرار رمز عبور باید با رمز عبور مطابقت داشته باشد";
        public const string SignUpSuccessful = "ثبت نام شما انجام شد";
        public const string ExistingUserName = "این نام کاربری از قبل انتخاب شده";
        public const string Error = "مشکلی پیش امده لطفا با پشتیبانی تماس بگیرید";
        public const string CodeError = "کد خطا:  ";
        public const string EnterUsernameAndPassword = "نام کاربری و رمز عبور را وارد کنید";
        public const string InvalidPasswordAndUsername = "رمز عبور یا نام کاربری صحیح نمیباشد";
        public const string UserNotFound = "کاربر پیدا نشد";
    }
}
