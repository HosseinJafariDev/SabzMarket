using Application.Interfaces;
using Application.Interfaces.Repositories;

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
            services.AddScoped<IFeaturedSellerRepository, FeaturedSellerRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ILogServiceRepository, LogServiceRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IErrorService, ErrorService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<ICategoriService, CategoriService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IProductOrderDetailHelperService, ProductOrderDetailHelperService>();
            services.AddScoped<IFarmerService, FarmerService>();
            services.AddScoped<IFeaturedSellerSevice, FeaturedSellerSevice>();
            services.AddScoped<ICartItemService, CartItemService>();

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
