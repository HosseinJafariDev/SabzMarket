using Amazon.Runtime;
using Amazon.S3;
using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Options;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
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
using SabzMarket.Infrastructure.Configuration.S3;
using SabzMarket.Infrastructure.Logging;
using SabzMarket.Infrastructure.Persistence.QueryServices;
using SabzMarket.Infrastructure.Persistence.Repository;
using SabzMarket.Infrastructure.SignalR;
using SabzMarket.Infrastructure.Sms;
using SabzMarket.Infrastructure.Storage;
using SabzMarket.Infrastructure.TokenService;

namespace SabzMarket.API.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<ICategorieRepository, CategorieRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IFarmerRepository, FarmerRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ISmsOtpRepository, SmsOtpRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();

            return services;
        }

        public static IServiceCollection AddQueryService(this IServiceCollection services)
        {
            services.AddScoped<IOrderQueryService, OrderQueryService>();
            services.AddScoped<IFeaturedSellerQueryService, FeaturedSellerQueryService>();
            services.AddScoped<IFarmerQueryService, FarmerQueryService>();
            services.AddScoped<ICartItemQueryService, CartItemQueryService>();
            services.AddScoped<IChatQueryService, ChatQueryService>();
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAmazonS3>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<S3Settings>>().Value;
                var config = new AmazonS3Config
                {
                    ServiceURL = settings.ServiceURL,
                    ForcePathStyle = true,
                    AuthenticationRegion = settings.Region
                };
                var credentials = new BasicAWSCredentials(settings.AccessKey, settings.SecretKey);
                return new AmazonS3Client(credentials, config);
            });

            services.AddScoped<IFileStorageService, S3FileStorageService>();
            services.AddScoped<IFileLogService, FileLogService>();
            services.AddScoped<ISendSmsService, SendSmsService>();
            services.AddSingleton<IConnectionManager, ConnectionManager>();
            services.AddScoped<ITokenService, JwtTokenService>();

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddUseCase(this IServiceCollection services)
        {
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
            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(SignUpProfile).Assembly);
            return services;
        }

        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<SignUpValidator>();
            return services;
        }
    }
}