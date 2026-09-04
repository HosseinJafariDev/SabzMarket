using FluentValidation;
using SabzMarket.Application.Interfaces.Persistence;
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
using SabzMarket.Infrastructure.Persistence.QueryServices;
using SabzMarket.Infrastructure.Persistence.Repository;

namespace SabzMarket.API.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<SignUpValidator>();
            return services;
        }
    }
}