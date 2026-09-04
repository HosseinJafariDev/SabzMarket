using Microsoft.EntityFrameworkCore;
using SabzMarket.API.DependencyInjection;
using SabzMarket.API.Hubs;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.TokenService.Configuration;
using SabzMarket.Infrastructure;
using SabzMarket.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("Jwt"));
var jwtConfig = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtConfiguration>();
builder.Services.AddJwtAuthentication(jwtConfig!);
builder.Services.AddAuthorization();


builder.Services
    .AddValidator()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);


builder.Services.AddControllers();
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
    app.UseSwaggerUI(op => { op.DisplayRequestDuration(); });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

app.Run();