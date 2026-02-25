using Amazon.Runtime;
using Amazon.S3;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SabzMarket.API.DependencyInjection;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Application.UseCases.Auth.Mappers;
using SabzMarket.Infrastructure.Configuration;
using SabzMarket.Infrastructure.Persistence;
using SabzMarket.Infrastructure.Storage;
using System.Runtime;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("SABZMARKET_DB");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("? Connection string not found. Please set environment variable: SABZMARKET_DB");
}

var s3Settings = builder.Configuration.GetSection("S3").Get<S3Settings>();
builder.Services.AddSingleton(s3Settings);
//builder.Services.AddAutoMapper(typeof(SignUpProfile));

builder.Services.AddScoped<IAmazonS3>(sp =>
{
    var settings = sp.GetRequiredService<S3Settings>();
    var config = new AmazonS3Config
    {
        ServiceURL = settings.ServiceURL,
        ForcePathStyle = true,
        AuthenticationRegion = settings.Region
    };
    var credentials = new BasicAWSCredentials(settings.AccessKey, settings.SecretKey);
    return new AmazonS3Client(credentials, config);
});


builder.Services.AddScoped<IFileStorageService, S3FileStorageService>();

builder.Services
    .AddDatabase(connectionString)
    .AddRepositories()
    .AddApplicationServices()
    .AddUnitOfWork();
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// Add services to the container.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<SabzMarketDbContext>();

    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
