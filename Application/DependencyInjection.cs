using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SabzMarket.Application.UseCases.Auth.Login;
using SabzMarket.Application.UseCases.Auth.Mappers;
using SabzMarket.Application.UseCases.Auth.SignUp;
using SabzMarket.Application.UseCases.Auth.UserIsFarmer;
using SabzMarket.Application.UseCases.Auth.UserIsSeller;
using SabzMarket.Application.UseCases.CartItems.AddToCart;
using SabzMarket.Application.UseCases.CartItems.DecreaseQuantity;
using SabzMarket.Application.UseCases.CartItems.DeleteCartItem;
using SabzMarket.Application.UseCases.CartItems.GetCartItem;
using SabzMarket.Application.UseCases.Categories.GetCategory;
using SabzMarket.Application.UseCases.Chats.findUsersChatted;
using SabzMarket.Application.UseCases.Chats.GetMessage;
using SabzMarket.Application.UseCases.Chats.SendMessage;
using SabzMarket.Application.UseCases.Erorr;
using SabzMarket.Application.UseCases.Farmers.CreateFarmer;
using SabzMarket.Application.UseCases.Farmers.GetFarmer;
using SabzMarket.Application.UseCases.Farmers.UpdateFarmer;
using SabzMarket.Application.UseCases.FeaturedSellers.GetFeaturedSeller;
using SabzMarket.Application.UseCases.OrderDetails.MarkOrderDetail;
using SabzMarket.Application.UseCases.Orders.Checkout;
using SabzMarket.Application.UseCases.Orders.GetOrders;
using SabzMarket.Application.UseCases.Products.CreateProduct;
using SabzMarket.Application.UseCases.Products.DeleteProduct;
using SabzMarket.Application.UseCases.Products.GetProduct;
using SabzMarket.Application.UseCases.Products.UpdateProduct;
using SabzMarket.Application.UseCases.Sellers.CreateSeller;
using SabzMarket.Application.UseCases.Sellers.GetSeller;
using SabzMarket.Application.UseCases.Sellers.UpdateSeller;
using SabzMarket.Application.UseCases.Sms.SendSmsOtp;
using SabzMarket.Application.UseCases.Users.GetUser;

namespace SabzMarket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        #region UseCase

        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<ISendSmsOtpUseCase, SendSmsOtpUseCase>();
        services.AddScoped<ISignUpUseCase, SignUpUseCase>();
        services.AddScoped<IUserIsFarmerUseCase, UserIsFarmerUseCase>();
        services.AddScoped<IUserIsSellerUseCase, UserIsSellerUseCase>();
        services.AddScoped<IAddToCartUseCase, AddToCartUseCase>();
        services.AddScoped<IDecreaseQuantityUseCase, DecreaseQuantityUseCase>();
        services.AddScoped<IDeleteCartItemUseCase, DeleteCartItemUseCase>();
        services.AddScoped<IGetCartItemByFarmerIdUseCase, GetCartItemByFarmerIdUseCase>();
        services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddScoped<IAddLogErrorUseCase, AddLogErrorUseCase>();
        services.AddScoped<ICreateFarmerUseCase, CreateFarmerUseCase>();
        services.AddScoped<IGetFarmerByUsernameUseCase, GetFarmerByUsernameUseCase>();
        services.AddScoped<IUpdateFarmerUseCase, UpdateFarmerUseCase>();
        services.AddScoped<IGetAllSellerUseCase, GetAllSellerUseCase>();
        services.AddScoped<IMarkOrderDetailAsRejectedUseCase, MarkOrderDetailAsRejectedUseCase>();
        services.AddScoped<IMarkOrderDetailAsSentUseCase, MarkOrderDetailAsSentUseCase>();
        services.AddScoped<ICheckoutOrderUseCase, CheckoutOrderUseCase>();
        services.AddScoped<IGetNonPendingOrdersForSellerUseCase, GetNonPendingOrdersForSellerUseCase>();
        services.AddScoped<IGetPendingOrdersForSellerUseCase, GetPendingOrdersForSellerUseCase>();
        services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
        services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
        services.AddScoped<IGetProductByNameUseCase, GetProductByNameUseCase>();
        services.AddScoped<IGetProductBySellerIdUseCase, GetProductBySellerIdUseCase>();
        services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
        services.AddScoped<ICreateSellerUseCase, CreateSellerUseCase>();
        services.AddScoped<IGetSellerByUsenameUseCase, GetSellerByUsenameUseCase>();
        services.AddScoped<IGetSellerByIdUseCase, GetSellerByIdUseCase>();
        services.AddScoped<IGetAllSellerByPhoneNumberUseCase, GetAllSellerByPhoneNumberUseCase>();
        services.AddScoped<ISellerUpdateUseCase, SellerUpdateUseCase>();
        services.AddScoped<IGetUserByUserNameUseCase, GetUserByUserNameUseCase>();
        services.AddScoped<ISendMessageUseCase, SendMessageUseCase>();
        services.AddScoped<IFindUsersChattedWithIdUseCase, findUsersChattedWithIdUseCase>();
        services.AddScoped<IGetMessageUseCase, GetMessageUseCase>();

        #endregion

        #region AutoMapper

        services.AddAutoMapper(cfg => { }, typeof(SignUpProfile).Assembly);

        #endregion


        return services;
    }
}