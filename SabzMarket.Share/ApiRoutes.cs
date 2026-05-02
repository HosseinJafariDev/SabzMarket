using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Share
{
    public class ApiRoutes
    {
        public const string SignUp = "Auth/SignUp";
        public const string Login = "Auth/Login";
        public const string SendOtp = "SendSmsOtp/Send?Phone={0}";
        public const string SellerFillProfile = "Seller/CreateSelller";
        public const string GetSellerByPhoneNumber = "Seller/GetByPhoneNumber?phone={0}";
        public const string CheckUserInSeller = "Seller/CheckUserInSeller?username={0}";
        public const string GetSellerByUsername = "Seller/GetSellerByUsername?username={0}";
        public const string GetSellerById = "Seller/GetById?id={0}";
        public const string UpdateSeller = "Seller/Update?username={0}";
        public const string GetCategori = "Categori/GetAllCategories";
        public const string CreateProduct = "Product/CreateProduct";
        public const string GetUser = "User/GetUser?username={0}";
        public const string LogError = "Error/LogError";
        public const string GetPendingOrdersForSeller = "Order/GetPendingOrdersForSeller?id={0}&search={1}";
        public const string GetNonPendingOrdersForSeller = "Order/GetNonPendingOrdersForSeller?id={0}&search={1}";
        public const string OrderDetailRejected = "OrderDetail/MarkOrderDetailAsRejected?orderDetaileId={0}&number={1}&productId={2}";
        public const string OrderDetailSent = "OrderDetail/MarkOrderDetailAsSent?orderDetaileId={0}";
        public const string GetProductBySellerId = "Product/GetProductsBySeller?sellerId={0}";
        public const string DeleteProduct = "Product/Delete?id={0}";
        public const string UpdateProduct = "Product/Update";
        public const string GetProductByName = "Product/GetByName?search={0}";
        //===============================================================================================================================
        public const string CheckUserInFarmer = "Farmer/CheckUserExistsInFarmer?username={0}";
        public const string CreateFarmer = "Farmer/CreateFarmer?username={0}";
        public const string GetFarmerFullByUsername = "Farmer/GetByUsername?username={0}";
        public const string UpdateFarmer = "Farmer/Update?username={0}";
        //===============================================================================================================================
        public const string GetFeaturedSeller = "FeaturedSeller/GetAllSeller";
        //===============================================================================================================================
        public const string RemoveCartItem = "CartItem/Delete?cartId={0}&productId={1}&productNumber={2}";
        public const string AddToCart = "CartItem/AddToCart";
        public const string DecreaseQuantity = "CartItem/DecreaseQuantity?productId={0}&farmerId={1}";
        public const string SelectCartByFarmerId = "CartItem/GetByFarmerId?farmerId={0}";
        //===============================================================================================================================
        public const string Checkout = "Order/Checkout?farmerId={0}";
        //===============================================================================================================================
        public const string FindUsersChattedWithId = "Chat/FindUsersChattedWithId?id={0}";
        public const string GetMessage = "Chat/GetMessage?fromId={0}&toId={1}";
        public const string SendMessage = "Chat/SendMessage";
    }
}
