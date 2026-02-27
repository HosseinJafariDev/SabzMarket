using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SabzMarket.API.DependencyInjection;
using SabzMarket.Application.UseCases.Auth.Mappers;
using SabzMarket.Infrastructure.Configuration;
using SabzMarket.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("SABZMARKET_DB");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("? Connection string not found. Please set environment variable: SABZMARKET_DB");
}

var s3Settings = builder.Configuration.GetSection("S3").Get<S3Settings>();

builder.Services
    .AddDatabase(connectionString)
    .AddRepositories()
    .AddInfrastructureServices(s3Settings!)
    .AddUnitOfWork()
    .AddUseCase()
    .AddAutoMapper()
    .AddValidator();




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

app.Run();
