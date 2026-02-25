using Microsoft.EntityFrameworkCore;
using SabzMarket.Infrastructure.Persistence;

namespace SabzMarket.API.DependencyInjection
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        string connectionString)
        {
            services.AddDbContextFactory<SabzMarketDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<SabzMarketDbContext>(sp =>
                sp.GetRequiredService<IDbContextFactory<SabzMarketDbContext>>()
                  .CreateDbContext());

            return services;
        }
    }
}
