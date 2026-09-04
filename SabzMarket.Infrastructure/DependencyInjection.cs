using Amazon.Runtime;
using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities.Log;
using SabzMarket.Infrastructure.Logging;
using SabzMarket.Infrastructure.Persistence.Mongo;
using SabzMarket.Infrastructure.Persistence.Mongo.Repositories;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.Persistence.Repository;
using SabzMarket.Infrastructure.SignalR;
using SabzMarket.Infrastructure.Sms;
using SabzMarket.Infrastructure.Storage;
using SabzMarket.Infrastructure.Storage.Configuration;
using SabzMarket.Infrastructure.TokenService;
using SabzMarket.Infrastructure.TokenService.Configuration;

namespace SabzMarket.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Add Database Sql

        services.AddDbContext<SabzMarketDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));

        #endregion
    
        #region Repository

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<ICategorieRepository, CategorieRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IFarmerRepository, FarmerRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<ISmsOtpRepository, SmsOtpRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();

        #endregion

        #region Service

        services.Configure<S3Settings>(configuration.GetSection("S3"));
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

        #endregion

        #region UnitOfWork

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        #endregion

        #region Mongo

        services.Configure<MongoSettings>(configuration.GetSection(MongoSettings.SectionName));
        services.AddSingleton<MongoContext>();
        services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();
        BsonClassMap.RegisterClassMap<ExceptionLog>(map =>
        {
            map.AutoMap();

            map.MapIdMember(x => x.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));

            map.SetIgnoreExtraElements(true);
        });

        #endregion
    }
}