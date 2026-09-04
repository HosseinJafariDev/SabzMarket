using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using SabzMarket.API.DependencyInjection;
using SabzMarket.API.Hubs;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.TokenService.Configuration;
using SabzMarket.Infrastructure;
using SabzMarket.Application;
using Scalar.AspNetCore;

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

builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
    })
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    })
    .AddOpenApi(options => options.Document.AddScalarTransformers());

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
    app.UseSwaggerUI(op =>
    {
        op.DisplayRequestDuration();

        foreach (var description in app.DescribeApiVersions())
        {
            op.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });

    app.MapOpenApi().WithDocumentPerVersion();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Shop API");

        var descriptions = app.DescribeApiVersions();

        for (var index = 0; index < descriptions.Count; index++)
        {
            var description = descriptions[index];
            //var isDefault = index == descriptions.Count - 1;
            var isDefault = index == 0;

            options.AddDocument(
                description.GroupName,
                description.GroupName.ToUpperInvariant(),
                isDefault: isDefault);
        }
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

app.Run();