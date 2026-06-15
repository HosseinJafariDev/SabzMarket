using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SabzMarket.API.DependencyInjection;
using SabzMarket.API.Hubs;
using SabzMarket.Application.UseCases.Auth.Mappers;
using SabzMarket.Infrastructure.Configuration.JwtToken;
using SabzMarket.Infrastructure.Configuration.S3;
using SabzMarket.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("SABZMARKET_DB");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("? Connection string not found. Please set environment variable: SABZMARKET_DB");
}

builder.Services.AddSignalR();

builder.Services.Configure<S3Settings>(builder.Configuration.GetSection("S3"));
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("Jwt"));

builder.Services
    .AddDatabase(connectionString)
    .AddRepositories()
    .AddInfrastructureServices()
    .AddUnitOfWork()
    .AddUseCase()
    .AddAutoMapper()
    .AddValidator()
    .AddQueryService();


// Add services to the container.
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins",
//        builder => builder.AllowAnyOrigin()
//                        .AllowAnyHeader()
//                        .AllowAnyMethod());
//});

var app = builder.Build();

app.UseCustomExceptionHandler();

//app.UseCors("AllowAllOrigins");

//CreateDatabase
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

app.MapHub<ChatHub>("/chatHub");

app.Run();