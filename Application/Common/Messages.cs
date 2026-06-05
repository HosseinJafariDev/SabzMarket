using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SabzMarket.Application.Common
{
    public static class Messages
    {
        public const string Url = "http";
        public const string SavePhotoLayer = "SavePhoto";
        public const string UnsuccessfulSavePhoto = "تصویر ذخیره نشد با پشتیبانی تماس بگیرید";
        public const string FirstNameMaxLength = "نام باید حداکثر 50 کاراکتر باشد";
        public const string FirstNameMinLength = "نام باید حداقل 3 کاراکتر باشد";
        public const string LastNameMaxLength = "نام خانوادگی باید حداکثر 50 کاراکتر باشد";
        public const string LastNameMinLength = "نام خانوادگی باید حداقل 2 کاراکتر باشد";
        public const string PhoneInvalid = "شماره تلفن معتبر نمی باشد";
        public const string PhoneRequired = "شماره تلفن الزامی است";
        public const string UserNameRequired = "لطفا نام کاربری برای خود انتخاب کنید";
        public const string UserNameMinLength = "نام کاربری حداقل 6 کاراکتر باشد";
        public const string UserNameMaxLength = "نام کاربری باید حداکثر 50 کاراکتر باشد";
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
        public const string EnterOtp = "کد ورود را وارد کنید";
        public const string InvalidOtp = "کد ورود صحیح نمی باشد";
        public const string InvalidPasswordAndUsername = "رمز عبور یا نام کاربری صحیح نمیباشد";
        public const string UserNotFound = "کاربر پیدا نشد";
        public const string AddressRequired = "وارد کردن آدرس الزامی است";
        public const string AddressMaxLength = "آدرس باید حداکثر 500 کاراکتر باشد";
        public const string ProfileImageRequired = "یک تصویر برای پروفایل انتخاب کنید";
        public const string WorkHistoryMinlength = "سابقه کاری باید حداقل 1 باشد";
        public const string WorkHistoryMaxLength = "سابقه کاری باید حداکثر 999 باشد";
        public const string SaveSellerProfileSuccessful = "پروفایل فروشنده با موفقیت تکمیل شد";
        public const string NoSellerFoundWithId = "فروشنده ای با این ایدی پیدا نشد";
        public const string NoSellerFoundWithPhone = "فروشنده ای با این شماره تلفن پیدا نشد";
        public const string NoSellerFoundWhithUsename = "فروشنده ای با این نام کاربری پیدا نشد";
        public const string UpdateSuccessful = "ویرایش شد";
        public const string ProductNameRequired = "نام محصول الزامی است";
        public const string ProductDescriptionRequired = "توضیحات محصول الزامی است";
        public const string ProductDescriptionMaxLength = "توضیحات محصول باید  حداکثر 500کاراکتر باشد";
        public const string ProductNumberRequired = "تعداد محصول الزامی است";
        public const string ProductPriceRequired = "قیمت محصول الزامی است";
        public const string ProductImageRequired = "تصویری برای محصول انتخاب کنید";
        public const string CreateProductSuccessful = "محصول اضافه شد";
        public const string ProductNotFoundByName = "محصولی با این نام پیدا نشد";
        public const string ProductNotFoundBySellerId = "محصولی برای این فروشنده پیدا نشد";
        public const string ProductIsOnOrder = "این مجصول داره سفارش است . ابتدا تکلیف محصول را مشخص کنید سپس اقدام به حذف کنید";
        public const string ProductDelete = "محصول حذف شد";
        public const string OrderAlreadyRejectedMessage = "این سفارش قبلا رد شده است";
        public const string OrderReject = "سفارش رد شد";
        public const string OrderSent = "سفارش ارسال شد";
        public const string NotFoundPendingOrders = "محصولی پیدا نشد";
        public const string CartEmpty = "سبد خرید خالی است";
        public const string RemoveAddToCart = "با موفقیت از سبد خرید حذف شد";
        public const string SuccessAddToCart = "با موفقیت به سبد خرید اضافه شد";
        public const string UserIdRequired = "یوز آیدی الزامی است";
        public const string EnterDataBuilt = "تاریخ احداث را با فرمت 1380/12/24 وارد کنید ";
        public const string EnterLandArea = "مساحت زمین قابل کشت را به عدد وارد کنید";
        public const string NotValidNationalCode = "کد ملی معتبر نیست";
        public const string NationalCodeRequired = "کد ملی الزامی است";
        public const string EnterCodParvaneBHB = "شماره پروانه بهره برداری را درست وارد کنید";
        public const string EnterCodePosti = "کد پستی را درست وارد کنید";
        public const string ShoppingSuccessful = "خرید با موفقیت انجام شد";
        public const string NotFoundUsersChatted = "کاربری پیدا نشد";
    }
}
